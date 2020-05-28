using SolidWithCards.Cards;

namespace SolidWithCards.Dealers
{
	public interface IDealer
	{
		ICard Deal();

		void BurnCards();

		int RemainingCardTotal { get; }
	}
}
