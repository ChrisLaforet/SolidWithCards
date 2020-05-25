using System;
using System.Collections.Generic;
using System.Text;

namespace SolidWithCards
{
	interface IShuffler
	{
		Card[] Shuffle(Card[] cards);
	}
}
