
namespace SolidWithCards
{
	public class Card
	{
		public char Moniker { get; private set; }
		public Suit Suit { get; private set; }

		private Card(char moniker, Suit suit)
		{
			Moniker = moniker;
			Suit = suit;
		}
	}
}
