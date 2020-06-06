using NUnit.Framework;
using SolidWithCards.Blackjack;
using SolidWithCards.Cards;


namespace SolidWithCardsTests
{
	public class BlackjackTests
	{
		[Test]
		public void Validate_FaceCards_Equals10Points()
		{
			BlackjackCard card = new BlackjackCard(new TestCard("J", Suit.CLUBS));
			Assert.AreEqual(10, card.HardValue);
			Assert.AreEqual(10, card.SoftValue);

			card = new BlackjackCard(new TestCard("Q", Suit.CLUBS));
			Assert.AreEqual(10, card.HardValue);
			Assert.AreEqual(10, card.SoftValue);

			card = new BlackjackCard(new TestCard("K", Suit.CLUBS));
			Assert.AreEqual(10, card.HardValue);
			Assert.AreEqual(10, card.SoftValue);
		}

		[Test]
		public void Validate_AceCard_Equals11PointsSoftValue()
		{
			BlackjackCard card = new BlackjackCard(new TestCard("A", Suit.CLUBS));
			Assert.AreEqual(11, card.SoftValue);
		}

		[Test]
		public void Validate_AceCard_Equals1PointHardValue()
		{
			BlackjackCard card = new BlackjackCard(new TestCard("A", Suit.CLUBS));
			Assert.AreEqual(1, card.HardValue);
		}

		[Test]
		public void Validate_NumberCards_EqualsFaceValuePoints()
		{
			BlackjackCard card = new BlackjackCard(new TestCard("2", Suit.CLUBS));
			Assert.AreEqual(2, card.HardValue);
			Assert.AreEqual(2, card.SoftValue);

			card = new BlackjackCard(new TestCard("5", Suit.CLUBS));
			Assert.AreEqual(5, card.HardValue);
			Assert.AreEqual(5, card.SoftValue);

			card = new BlackjackCard(new TestCard("10", Suit.CLUBS));
			Assert.AreEqual(10, card.HardValue);
			Assert.AreEqual(10, card.SoftValue);
		}

		public class TestCard : ICard
		{
			private readonly string moniker;
			private readonly Suit suit;

			public string Moniker => moniker;
			public Suit Suit => suit;

			public TestCard(string moniker, Suit suit)
			{
				this.moniker = moniker;
				this.suit = suit;
			}
		}
	}
}
