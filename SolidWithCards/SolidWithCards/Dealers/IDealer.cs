using SolidWithCards.Cards;

namespace SolidWithCards.Dealers
{
	public interface IDealer
	{
		Card Deal();

		void BurnCards();

		int RemainingCardTotal { get; }
	}
}
