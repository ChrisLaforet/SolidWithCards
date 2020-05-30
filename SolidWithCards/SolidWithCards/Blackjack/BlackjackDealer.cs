using SolidWithCards.Cards;
using SolidWithCards.Dealers;
using System;

namespace SolidWithCards.Blackjack
{
	public class BlackjackDealer : IDealer
	{
		private readonly IDealer cardDealer;

		public BlackjackDealer(IDealer cardDealer)
		{
			this.cardDealer = cardDealer;
		}

		public int RemainingCardTotal => cardDealer.RemainingCardTotal;

		public void BurnCards()
		{
			cardDealer.BurnCards();
		}

		public ICard Deal()
		{
			return new BlackjackCard(cardDealer.Deal());
		}
	}
}
