using System;
using System.Collections.Generic;
using SolidWithCards.Cards;
using SolidWithCards.Shufflers;

namespace SolidWithCards.Dealers
{
	public class Deck : IDealer
	{
		private readonly Stack<Card> cardStack;

		public Deck(Card[] cards, IShuffler shuffler)
		{
			this.cardStack = new Stack<Card>(shuffler.Shuffle(cards));
		}

		public int RemainingCardTotal => cardStack.Count;

		public void BurnCards()
		{
			//if (!canBurn)
			//{
			//	throw new InvalidOperationException("Deck is already in use and can't be burned");
			//}
		}

		public ICard Deal()
		{
			try
			{
				return cardStack.Pop();
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
