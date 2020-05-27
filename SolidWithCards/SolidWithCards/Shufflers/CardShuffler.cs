using System;
using System.Collections.Generic;
using SolidWithCards.Cards;

namespace SolidWithCards.Shufflers
{
	public class CardShuffler : IShuffler
	{
		public Card[] Shuffle(Card[] cards)
		{
			int decks = cards.Length / 52;
			Card[] shuffled = cards;
			for (int times = 0; times < 13 * decks; times++)
			{
				shuffled = OverhandShuffle(shuffled);
				shuffled = CutCards(shuffled);
				shuffled = FisherYatesKnuthDurstenfieldShuffle(shuffled);
			}
			return shuffled;
		}

		private Card[] CutCards(Card[] cards)
		{
			Random random = new Random();
			int offset = random.Next(-cards.Length / 4, cards.Length / 4);
			int middle = cards.Length / 2 + offset;

			List<Card> newCards = new List<Card>();
			for (int count = middle; count < cards.Length; count++) 
			{
				newCards.Add(cards[count]);
			}
			for (int count = 0; count < middle; count++)
			{
				newCards.Add(cards[count]);
			}
			return newCards.ToArray();
		}

		private Card[] OverhandShuffle(Card[] cards)
		{
			Card[] newCards = new Card[cards.Length];

			int middle = cards.Length / 2;
			int source = middle;
			int dest = cards.Length - 1;
			while (source >= 0)
			{
				newCards[source] = cards[dest];
				newCards[dest] = cards[source];
				--source;
				--dest;
			}
			return newCards;
		}

		private Card[] FisherYatesKnuthDurstenfieldShuffle(Card[] cards)
		{
			Random random = new Random();
			Card[] newCards = new Card[cards.Length];
			cards.CopyTo(newCards, 0);
			for (int source = cards.Length - 1; source >= 0; source--)
			{
				int index = random.Next(source + 1);
				Card temp = newCards[index];
				newCards[index] = newCards[source];
				newCards[source] = temp;
			}

			return newCards;
		}
	}
}
