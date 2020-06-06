using SolidWithCards.Cards;
using System;
using System.Collections.Generic;

namespace SolidWithCards.Blackjack
{
	public class BlackjackGame : IStrategy
	{
		private const int MAX_PLAYERS = 7;

		private readonly int totalPlayers;
		private readonly BlackjackDealer dealer;
		private readonly List<Hand> playerHands = new List<Hand>();
		private Hand dealerHand;

		public BlackjackGame(int totalPlayers)
		{
			if (totalPlayers > MAX_PLAYERS)
			{
				throw new InvalidOperationException("Blackjack can be played by 1 to 7 players");
			}

			this.totalPlayers = totalPlayers;
			int decks = (totalPlayers + 2) / 2;
			this.dealer = new BlackjackDealer(DeckBuilder.CreateDealer(decks));
			this.dealer.BurnCards();
		}

		public void StartRound()
		{
			playerHands.Clear();
			for (int count = 0; count < totalPlayers; count++)
			{
				playerHands.Add(new Hand("Player " + (count + 1), this.dealer));
			}
			dealerHand = new Hand("House/Dealer", this.dealer);
		}

		public Hand[] PlayerHands => playerHands.ToArray();
		public Hand DealerHand => dealerHand;
	}
}
