using System.Linq;
using NUnit.Framework;
using SolidWithCards.Cards;
using SolidWithCards.Dealers;
using SolidWithCards.Shufflers;

namespace SolidWithCardsTests
{
	public class Tests
	{
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

		[Test]
		public void Validate_Shuffle_DoesNotLeaveNulls()
		{
			for (int count = 0; count < 23; count++) {
				Card[] pack = Card.NewPackOfCards;
				IShuffler shuffler = new CardShuffler();
				Card[] shuffled = shuffler.Shuffle(pack);

				Assert.IsFalse(shuffled.Contains(null));
			}
		}

		[Test]
		public void Validate_Shuffle_Randomizes()
		{
			Card[] pack = Card.NewPackOfCards;
			IShuffler shuffler = new CardShuffler();
			Card[] shuffled1 = shuffler.Shuffle(pack);
			Card[] shuffled2 = shuffler.Shuffle(pack);

			Assert.IsFalse(Enumerable.SequenceEqual(pack, shuffled1));
			Assert.IsFalse(Enumerable.SequenceEqual(pack, shuffled2));
			Assert.IsFalse(Enumerable.SequenceEqual(shuffled1, shuffled2));
		}

		[Test]
		public void Validate_Deck_Contains_52Cards()
		{
			IShuffler shuffler = new CardShuffler();
			Deck deck = new Deck(Card.NewPackOfCards, shuffler);
			int count = 0;
			while (deck.Deal() != null)
			{
				++count;
			}
			Assert.AreEqual(52, count);
		}

		[Test]
		public void Validate_Deck_CanBurn_And_CanDealACard()
		{
			IShuffler shuffler = new CardShuffler();
			Deck deck = new Deck(Card.NewPackOfCards, shuffler);
			deck.BurnCards();
			int remainingCardTotal = deck.RemainingCardTotal;
			Assert.AreNotEqual(52, remainingCardTotal);

			deck.Deal();
			Assert.AreEqual(remainingCardTotal - 1, deck.RemainingCardTotal);
		}

		[Test]
		public void Validate_2DeckShoe_Contains_104Cards()
		{
			IShuffler shuffler = new CardShuffler();
			Shoe shoe = new Shoe(Card.TwoNewPacksOfCards, shuffler);
			int count = 0;
			while (shoe.Deal() != null)
			{
				++count;
			}
			Assert.AreEqual(104, count);
		}

		[Test]
		public void Validate_4DeckShoe_Contains_208Cards()
		{
			IShuffler shuffler = new CardShuffler();
			Shoe shoe = new Shoe(Card.FourNewPacksOfCards, shuffler);
			int count = 0;
			while (shoe.Deal() != null)
			{
				++count;
			}
			Assert.AreEqual(208, count);
		}

		[Test]
		public void Validate_6DeckShoe_Contains_312Cards()
		{
			IShuffler shuffler = new CardShuffler();
			Shoe shoe = new Shoe(Card.SixNewPacksOfCards, shuffler);
			int count = 0;
			while (shoe.Deal() != null)
			{
				++count;
			}
			Assert.AreEqual(312, count);
		}

		[Test]
		public void Validate_8DeckShoe_Contains_416Cards()
		{
			IShuffler shuffler = new CardShuffler();
			Shoe shoe = new Shoe(Card.EightNewPacksOfCards, shuffler);
			int count = 0;
			while (shoe.Deal() != null)
			{
				++count;
			}
			Assert.AreEqual(416, count);
		}
	}
}