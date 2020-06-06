using System.Collections.Generic;
using System.Text;

namespace SolidWithCards.Blackjack
{
	public class Hand : IScorer
	{
		private const int MAX_VALUE = 21;
		private const int HOUSE_STAND_VALUE = 17;

		private readonly List<BlackjackCard> cards = new List<BlackjackCard>();
		private readonly string name;
		private readonly BlackjackDealer dealer;

		public int HardValue
		{
			get
			{
				int total = 0;
				cards.ForEach(card => total += card.HardValue);
				return total;
			}
		}

		public int SoftValue
		{
			get
			{
				int total = 0;
				cards.ForEach(card => total += card.SoftValue);
				return total;
			}
		}

		internal Hand(string name, BlackjackDealer dealer)
		{
			this.name = name;
			this.dealer = dealer;
			cards.Add(dealer.Deal() as BlackjackCard);
			cards.Add(dealer.Deal() as BlackjackCard);
		}

		public string Name => name;

		public bool IsBusted => HardValue > MAX_VALUE;

		public bool IsBlackjack => HardValue == MAX_VALUE || SoftValue == MAX_VALUE;

		public bool IsHouseStand => IsBlackjack || SoftValue >= HOUSE_STAND_VALUE;

		public BlackjackCard[] Cards => cards.ToArray();

		public void Hit()
		{
			if (HardValue < MAX_VALUE)
			{
				cards.Add(dealer.Deal() as BlackjackCard);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Name);
			sb.Append(" : Points are ");
			sb.Append(HardValue);
			sb.Append("/");
			sb.Append(SoftValue);
			sb.Append(" :: Cards are:");
			cards.ForEach(card => sb.Append("  ").Append(card.ToString()));
			return sb.ToString();
		}
	}
}
