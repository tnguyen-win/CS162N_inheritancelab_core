using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses {
	public class Hand {
		protected List<Card> cards;

		public int NumCards {
			get {
				return cards.Count;
			}
		}

		public void AddCard(Card c) {
			cards.Add(c);
		}

		public Card Discard(int i) {
			Card c = GetCard(i);

			cards.RemoveAt(i);

			return c;
		}

		public Card GetCard(int i) {
			return cards[i];
		}

		public Hand() {
			cards = new List<Card>();
		}

		public Hand(Deck d, int numCards) {
			cards = new List<Card>();

			for (var i = 0; i < numCards; i++) AddCard(d[i]);
		}

		public bool HasCard(Card c) {
			return IndexOf(c) != -1;
		}

		public bool HasCard(int v) {
			return GetCard(v).Value == v;
		}

		public bool HasCard(int s, int v) {
			return IndexOf(s, v) != -1;
		}

		public int IndexOf(Card c) {
			return cards.IndexOf(c);
		}

		public int IndexOf(int v) {
			return cards.IndexOf(cards[v]);
		}

		public int IndexOf(int s, int v) {
			foreach (Card c in cards) if (c.Suit == s) if (c.Value == v) return cards.IndexOf(c);

			return -1;
		}

		public override string ToString() {
			string output = "";

			foreach (Card c in cards) output += $"{c}\n";

			return output;
		}
	}
}