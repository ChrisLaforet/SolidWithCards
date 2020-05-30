using System;
using System.Collections.Generic;
using SolidWithCards.Cards;
using SolidWithCards.Shufflers;

namespace SolidWithCards.Dealers
{
	public class Shoe : IDealer
	{
		private const float MAX_CARDS_FOR_BURN_PERCENT = 0.25f;

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
				int limitCardsForBurn = (int)Math.Floor(MAX_CARDS_FOR_BURN_PERCENT * cardStack.Count);
				Random random = new Random();
				int max = random.Next(limitCardsForBurn);
				if (max < limitCardsForBurn /2)
				{
					max = limitCardsForBurn / 2;
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
