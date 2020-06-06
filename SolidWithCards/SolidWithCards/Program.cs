using SolidWithCards.Blackjack;
using System;

namespace SolidWithCards
{
	public class Program
	{
		static public void Main(string[] args)
		{
			Console.WriteLine("- - - B L A C K J A C K - - -");
			Console.WriteLine();
			BlackjackGame game = new BlackjackGame(1);
			do
			{
				Console.WriteLine(" - - New Game - -");
				game.StartRound();
				bool endOfRound = false;
				do
				{
					Console.WriteLine();
					foreach (var hand in game.PlayerHands)
					{
						Console.WriteLine(hand.ToString());
						if (hand.IsBusted)
						{
							Console.WriteLine("*** BUSTED ***");
							endOfRound = true;
						} else if (hand.IsBlackjack)
						{
							Console.WriteLine("! ! ! *** BLACKJACK *** ! ! !");
							endOfRound = true;
						}
					}
					Console.WriteLine(game.DealerHand.ToString());
					if (game.DealerHand.IsBusted)
					{
						Console.WriteLine("*** BUSTED ***");
						endOfRound = true;
					}
					else if (game.DealerHand.IsBlackjack)
					{
						Console.WriteLine("! ! ! *** BLACKJACK *** ! ! !");
						endOfRound = true;
					}

					while (!endOfRound)
					{
						Console.Write("\nDo you want to (H)it or (S)tand or (F)old? ");
						var choice = Console.ReadKey();
						if (Char.ToUpper(choice.KeyChar) == 'H')
						{
							game.PlayerHands[0].Hit();
							if (!game.DealerHand.IsHouseStand)
							{
								game.DealerHand.Hit();
							}
							break;
						} 
						else if (Char.ToUpper(choice.KeyChar) == 'S')
						{
							if (!game.DealerHand.IsHouseStand)
							{
								game.DealerHand.Hit();
							} 
							else
							{
								// TODO: Who won
								endOfRound = true;
							}
							break;
						}
						else if (Char.ToUpper(choice.KeyChar) == 'F')
						{
							Console.WriteLine("**** YOU FOLDED ****");
							endOfRound = true;
						}
					}

				} while (!endOfRound);

				Console.Write("\nPlay another round? ");
				var key = Console.ReadKey();
				if (Char.ToUpper(key.KeyChar) != 'Y')
				{
					break;
				}
			} while (true);
		}
	}
}
