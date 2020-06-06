using SolidWithCards.Dealers;
using SolidWithCards.Shufflers;

namespace SolidWithCards.Cards
{
	public class DeckBuilder
	{
		protected DeckBuilder()
		{
		}

		public static IDealer CreateDealer(int Packs = 1)
		{
			if (Packs == 1)
			{
				return new Deck(Card.LoadPacksOfCards(Packs), new CardShuffler()); 
			}

			return new Shoe(Card.LoadPacksOfCards(Packs), new CardShuffler());
		}
	}
}
