namespace SolidWithCards.Cards
{
	public class Suit
	{
		public string Color { get; private set; }
		public char Symbol { get; private set; }
		public string Name { get; private set; }

		private Suit(string name, char symbol, string color)
		{
			Color = color;
			Name = name;
			Symbol = symbol;
		}

		public static readonly Suit HEARTS = new Suit("Hearts", '♥', "Red");
		public static readonly Suit CLUBS = new Suit("Clubs", '♣', "Black");
		public static readonly Suit DIAMONDS = new Suit("Diamonds", '♦', "Red");
		public static readonly Suit SPADES = new Suit("Spades", '♠', "Black");
	}
}
