using System;
using System.Collections.Generic;
using SolidWithCards.Cards;
using SolidWithCards.Shufflers;

namespace SolidWithCards.Dealers
{
	public class Shoe : IDealer
	{
		private const int MAX_CARDS_FOR_BURN = 100;

		private readonly Stack<Card> cardStack;
		private bool canBurn = true;

		public Shoe(Card[] cards, IShuffler shuffler)
		{
			this.cardStack = new Stack<Card>(shuffler.Shuffle(cards));
		}

		public int RemainingCardTotal => cardStack.Count;

		public void BurnCards()
		{
			if (canBurn)
			{
				Random random = new Random();
				int max = random.Next(MAX_CARDS_FOR_BURN);
				if (max == 0)
				{
					max = MAX_CARDS_FOR_BURN;
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

		public Card Deal()
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
