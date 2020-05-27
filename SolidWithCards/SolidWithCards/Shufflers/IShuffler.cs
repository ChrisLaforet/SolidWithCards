using SolidWithCards.Cards;

namespace SolidWithCards.Shufflers
{
	public interface IShuffler
	{
		Card[] Shuffle(Card[] cards);
	}
}
