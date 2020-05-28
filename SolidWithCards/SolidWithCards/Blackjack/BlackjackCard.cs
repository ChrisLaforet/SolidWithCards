using SolidWithCards.Cards;
using System;


namespace SolidWithCards.Blackjack
{
	public class BlackjackCard : ICard, IScorer
	{
		private readonly ICard card;

		public BlackjackCard(ICard card)
		{
			this.card = card;
		}

		public int HardValue 
		{
			get
			{
				switch (card.Moniker)
				{
					case "A":
						return 1;

					case "J":
					case "Q":
					case "K":
					case "10":
						return 10;
				}
				return int.Parse(card.Moniker);
			}
		}

		public int SoftValue
		{
			get
			{
				if (card.Moniker == "A")
				{
					return 11;
				}
				return HardValue;
			}
		}

		public string Moniker => card.Moniker;

		public Suit Suit => card.Suit;
	}
}
