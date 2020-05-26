using System.Linq;
using NUnit.Framework;
using SolidWithCards;

namespace SolidWithCardsTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Validate_AskingForPackOfCards_Returns52Cards()
		{
			Card[] pack = Card.NewPackOfCards;
			Assert.AreEqual(52, pack.Length);
		}

		[Test]
		public void Validate_NewPackOfCards_Returns13OfEachSuit()
		{
			Card[] pack = Card.NewPackOfCards;
			int clubs = pack.AsQueryable().Where((card, index) => card.Suit == Suit.CLUBS).Count();
			Assert.AreEqual(13, clubs);
			int diamonds = pack.AsQueryable().Where((card, index) => card.Suit == Suit.DIAMONDS).Count();
			Assert.AreEqual(13, diamonds);
			int hearts = pack.AsQueryable().Where((card, index) => card.Suit == Suit.HEARTS).Count();
			Assert.AreEqual(13, hearts);
			int spades = pack.AsQueryable().Where((card, index) => card.Suit == Suit.SPADES).Count();
			Assert.AreEqual(13, spades);
		}
	}
}