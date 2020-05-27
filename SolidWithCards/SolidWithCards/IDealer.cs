
namespace SolidWithCards
{
	public interface IDealer
	{
		Card Deal();

		void BurnCards();

		int RemainingCardTotal { get; }
	}
}
