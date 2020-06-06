using System.Linq;
using NUnit.Framework;
using SolidWithCards.Cards;
using SolidWithCards.Dealers;
using SolidWithCards.Shufflers;

namespace SolidWithCardsTests
{
	public class BaseTests
	{
		[Test]
		public void Validate_AskingForPackOfCards_Returns52Cards()
		{
			Card[] pack = Card.LoadPacksOfCards(1);
			Assert.AreEqual(52, pack.Length);
		}

		[Test]
		public void Validate_NewPackOfCards_Returns13OfEachSuit()
		{
			Card[] pack = Card.LoadPacksOfCards(1);
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
				Card[] pack = Card.LoadPacksOfCards(1);
				IShuffler shuffler = new CardShuffler();
				Card[] shuffled = shuffler.Shuffle(pack);

				Assert.IsFalse(shuffled.Contains(null));
			}
		}

		[Test]
		public void Validate_Shuffle_Randomizes()
		{
			Card[] pack = Card.LoadPacksOfCards(1);
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
			Deck deck = new Deck(Card.LoadPacksOfCards(1), shuffler);
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
			Deck deck = new Deck(Card.LoadPacksOfCards(1), shuffler);
			deck.BurnCards();
			int remainingCardTotal = deck.RemainingCardTotal;
			Assert.AreEqual(52, remainingCardTotal);

			deck.Deal();
			Assert.AreEqual(remainingCardTotal - 1, deck.RemainingCardTotal);
		}

		[Test]
		public void Validate_2DeckShoe_Contains_104Cards()
		{
			IShuffler shuffler = new CardShuffler();
			Shoe shoe = new Shoe(Card.LoadPacksOfCards(2), shuffler);
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
			Shoe shoe = new Shoe(Card.LoadPacksOfCards(4), shuffler);
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
			Shoe shoe = new Shoe(Card.LoadPacksOfCards(6), shuffler);
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
			Shoe shoe = new Shoe(Card.LoadPacksOfCards(8), shuffler);
			int count = 0;
			while (shoe.Deal() != null)
			{
				++count;
			}
			Assert.AreEqual(416, count);
		}
	}
}