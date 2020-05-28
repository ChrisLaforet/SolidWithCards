using System;
using System.Collections.Generic;
using SolidWithCards.Cards;
using SolidWithCards.Shufflers;

namespace SolidWithCards.Dealers
{
	public class Deck : IDealer
	{
		private readonly Stack<Card> cardStack;
		private bool canBurn = true;

		public Deck(Card[] cards, IShuffler shuffler)
		{
			this.cardStack = new Stack<Card>(shuffler.Shuffle(cards));
		}

		public int RemainingCardTotal => cardStack.Count;

		public void BurnCards()
		{
			if (canBurn)
			{
				Random random = new Random();
				int max = random.Next((int)(cardStack.Count * 0.1));
				if (max == 0)
				{
					max = (int)(cardStack.Count * 0.1);
				}
				for (int count = 0; count < max; count++)
				{
					cardStack.Pop();
				}
			}
			else
			{
				throw new InvalidOperationException("Deck is already in use and can't be burned");
			}
		}

		public ICard Deal()
		{
			try
			{
				canBurn = false;
				return cardStack.Pop();
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
