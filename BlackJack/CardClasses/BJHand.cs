using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses {
	public class BJHand : Hand {
		public BJHand() : base() { }
		public BJHand(Deck d, int numCards) : base(d, numCards) { }

		public bool HasAce {
			get {
				return HasCard(1);
			}
		}

		public bool IsBusted {
			get {
				return NumCards > 21;
			}
		}

		public int Score {
			get {
				int score = 0;

				foreach (Card c in cards) score += c.IsFaceCard(c.Value) ? 10 : c.Value;

				return score;
			}
		}
	}
}