
using System.Collections.Generic;
using System.Linq;

namespace SolidWithCards.Cards
{
	public class Card : ICard
	{
		public string Moniker { get; private set; }
		public Suit Suit { get; private set; }

		private Card(string moniker, Suit suit)
		{
			Moniker = moniker;
			Suit = suit;
		}

		static Card[] NewPackOfCards
		{
			get
			{
				return new Card[] {
					ACE_HEARTS, TWO_HEARTS, THREE_HEARTS, FOUR_HEARTS,
					FIVE_HEARTS, SIX_HEARTS, SEVEN_HEARTS, EIGHT_HEARTS,
					NINE_HEARTS, TEN_HEARTS, JACK_HEARTS, QUEEN_HEARTS,
					KING_HEARTS,

					ACE_CLUBS, TWO_CLUBS, THREE_CLUBS, FOUR_CLUBS,
					FIVE_CLUBS, SIX_CLUBS, SEVEN_CLUBS, EIGHT_CLUBS,
					NINE_CLUBS, TEN_CLUBS, JACK_CLUBS, QUEEN_CLUBS,
					KING_CLUBS,

					ACE_DIAMONDS, TWO_DIAMONDS, THREE_DIAMONDS, FOUR_DIAMONDS,
					FIVE_DIAMONDS, SIX_DIAMONDS, SEVEN_DIAMONDS, EIGHT_DIAMONDS,
					NINE_DIAMONDS, TEN_DIAMONDS, JACK_DIAMONDS, QUEEN_DIAMONDS,
					KING_DIAMONDS,

					ACE_SPADES, TWO_SPADES, THREE_SPADES, FOUR_SPADES,
					FIVE_SPADES, SIX_SPADES, SEVEN_SPADES, EIGHT_SPADES,
					NINE_SPADES, TEN_SPADES, JACK_SPADES, QUEEN_SPADES,
					KING_SPADES };
			}
		}

		public static Card[] TwoNewPacksOfCards
		{
			get
			{
				return LoadPacksOfCards(2);
			}
		}

		public static Card[] FourNewPacksOfCards
		{
			get
			{
				return LoadPacksOfCards(4);
			}
		}

		public static Card[] SixNewPacksOfCards
		{
			get
			{
				return LoadPacksOfCards(6);
			}
		}

		public static Card[] EightNewPacksOfCards
		{
			get
			{
				return LoadPacksOfCards(8);
			}
		}

		private static Card[] LoadPacksOfCards(int packs)
		{
			List<Card> cards = new List<Card>();
			for (int pack = 0; pack < packs; pack++)
			{
				cards.AddRange(NewPackOfCards.ToList());
			}
			return cards.ToArray();
		}

		public static readonly Card ACE_HEARTS = new Card("A", Suit.HEARTS);
		public static readonly Card TWO_HEARTS = new Card("2", Suit.HEARTS);
		public static readonly Card THREE_HEARTS = new Card("3", Suit.HEARTS);
		public static readonly Card FOUR_HEARTS = new Card("4", Suit.HEARTS);
		public static readonly Card FIVE_HEARTS = new Card("5", Suit.HEARTS);
		public static readonly Card SIX_HEARTS = new Card("6", Suit.HEARTS);
		public static readonly Card SEVEN_HEARTS = new Card("7", Suit.HEARTS);
		public static readonly Card EIGHT_HEARTS = new Card("8", Suit.HEARTS);
		public static readonly Card NINE_HEARTS = new Card("9", Suit.HEARTS);
		public static readonly Card TEN_HEARTS = new Card("10", Suit.HEARTS);
		public static readonly Card JACK_HEARTS = new Card("J", Suit.HEARTS);
		public static readonly Card QUEEN_HEARTS = new Card("Q", Suit.HEARTS);
		public static readonly Card KING_HEARTS = new Card("K", Suit.HEARTS);

		public static readonly Card ACE_CLUBS = new Card("A", Suit.CLUBS);
		public static readonly Card TWO_CLUBS = new Card("2", Suit.CLUBS);
		public static readonly Card THREE_CLUBS = new Card("3", Suit.CLUBS);
		public static readonly Card FOUR_CLUBS = new Card("4", Suit.CLUBS);
		public static readonly Card FIVE_CLUBS = new Card("5", Suit.CLUBS);
		public static readonly Card SIX_CLUBS = new Card("6", Suit.CLUBS);
		public static readonly Card SEVEN_CLUBS = new Card("7", Suit.CLUBS);
		public static readonly Card EIGHT_CLUBS = new Card("8", Suit.CLUBS);
		public static readonly Card NINE_CLUBS = new Card("9", Suit.CLUBS);
		public static readonly Card TEN_CLUBS = new Card("10", Suit.CLUBS);
		public static readonly Card JACK_CLUBS = new Card("J", Suit.CLUBS);
		public static readonly Card QUEEN_CLUBS = new Card("Q", Suit.CLUBS);
		public static readonly Card KING_CLUBS = new Card("K", Suit.CLUBS);

		public static readonly Card ACE_DIAMONDS = new Card("A", Suit.DIAMONDS);
		public static readonly Card TWO_DIAMONDS = new Card("2", Suit.DIAMONDS);
		public static readonly Card THREE_DIAMONDS = new Card("3", Suit.DIAMONDS);
		public static readonly Card FOUR_DIAMONDS = new Card("4", Suit.DIAMONDS);
		public static readonly Card FIVE_DIAMONDS = new Card("5", Suit.DIAMONDS);
		public static readonly Card SIX_DIAMONDS = new Card("6", Suit.DIAMONDS);
		public static readonly Card SEVEN_DIAMONDS = new Card("7", Suit.DIAMONDS);
		public static readonly Card EIGHT_DIAMONDS = new Card("8", Suit.DIAMONDS);
		public static readonly Card NINE_DIAMONDS = new Card("9", Suit.DIAMONDS);
		public static readonly Card TEN_DIAMONDS = new Card("10", Suit.DIAMONDS);
		public static readonly Card JACK_DIAMONDS = new Card("J", Suit.DIAMONDS);
		public static readonly Card QUEEN_DIAMONDS = new Card("Q", Suit.DIAMONDS);
		public static readonly Card KING_DIAMONDS = new Card("K", Suit.DIAMONDS);

		public static readonly Card ACE_SPADES = new Card("A", Suit.SPADES);
		public static readonly Card TWO_SPADES = new Card("2", Suit.SPADES);
		public static readonly Card THREE_SPADES = new Card("3", Suit.SPADES);
		public static readonly Card FOUR_SPADES = new Card("4", Suit.SPADES);
		public static readonly Card FIVE_SPADES = new Card("5", Suit.SPADES);
		public static readonly Card SIX_SPADES = new Card("6", Suit.SPADES);
		public static readonly Card SEVEN_SPADES = new Card("7", Suit.SPADES);
		public static readonly Card EIGHT_SPADES = new Card("8", Suit.SPADES);
		public static readonly Card NINE_SPADES = new Card("9", Suit.SPADES);
		public static readonly Card TEN_SPADES = new Card("10", Suit.SPADES);
		public static readonly Card JACK_SPADES = new Card("J", Suit.SPADES);
		public static readonly Card QUEEN_SPADES = new Card("Q", Suit.SPADES);
		public static readonly Card KING_SPADES = new Card("K", Suit.SPADES);
	}
}
