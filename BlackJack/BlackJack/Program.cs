using System;
using System.ComponentModel;
using CardClasses;

namespace BlackJack {
	class Program {
		static void Program1() {
			// get the number of cards in the hand
			GetNumCards();
			Console.WriteLine("\n");
			// add a card object
			AddCard();
			Console.WriteLine("\n");
			// discard a specific card from the hand (and return that card to the calling code)
			RemoveCardAtIndex();
			Console.WriteLine("\n");
			// get a card based on its index
			GetCardAtIndex();
			Console.WriteLine("\n");
			// determine if a hand "has" or contains a card when given one of the following:  a card object, a value and a suit, just a value (as in "Do you have a 3?" for Go Fish)
			CheckHand1();
			Console.WriteLine("\n");
			// determine the index of a card in a hand when given one of the following:  a card object, a value and a suit, just a value
			CheckHand2();
			Console.WriteLine("\n");
			// convert its attributes to a string for displaying on the screen
			DisplayCardAttributes();
			Console.WriteLine("\n");

			static void GetNumCards() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[get the number of cards in the hand]");
				Console.WriteLine("Expected - [2].");
				Console.WriteLine($"Got - [{bjHand.NumCards}].");
			}

			static void AddCard() {
				Deck d = new();
				Random generator = new();
				Card c = new(generator.Next(1, 4), generator.Next(1, 13));

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				bjHand.AddCard(c);

				Console.WriteLine("[add a card object]");
				Console.WriteLine("Expected - three randomly generated cards.");
				Console.WriteLine($"Got - [\n{bjHand}].");
			}

			static void RemoveCardAtIndex() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[discard a specific card from the hand (and return that card to the calling code)]");
				Console.WriteLine($"Init - [\n{bjHand}].");
				Console.WriteLine($"Removed - Removed card at index 0, [{bjHand.Discard(0)}].");
				Console.WriteLine("Expected - one randomly generated card.");
				Console.WriteLine($"Remaining - [{bjHand}].");
			}

			static void GetCardAtIndex() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[get a card based on its index]");
				Console.WriteLine($"Init - [\n{bjHand}].");
				Console.WriteLine("Expected - card at index 1.");
				Console.WriteLine($"Got - [{bjHand.GetCard(1)}].");
			}

			static void CheckHand1() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[determine if a hand 'has' or contains a card when given one of the following:  a card object, a value and a suit, just a value (as in 'Do you have a 3?' for Go Fish)]");
				Console.WriteLine($"Init - At index 1, [{bjHand.GetCard(1)}].");
				Console.WriteLine("Expected - [True].");
				Console.WriteLine("Expected - [True].");
				Console.WriteLine("Expected - [True].");
				Console.WriteLine($"Got - [{bjHand.HasCard(bjHand.GetCard(1))}].");
				Console.WriteLine($"Got - [{bjHand.HasCard(1)}].");
				Console.WriteLine($"Got - [{bjHand.HasCard(bjHand.GetCard(1).Suit, bjHand.GetCard(1).Value)}].");
			}

			static void CheckHand2() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[determine the index of a card in a hand when given one of the following:  a card object, a value and a suit, just a value]");
				Console.WriteLine($"Init - At index 1, [{bjHand.GetCard(1)}].");
				Console.WriteLine("Expected - [1].");
				Console.WriteLine("Expected - [1].");
				Console.WriteLine("Expected - [1].");
				Console.WriteLine($"Got - [{bjHand.IndexOf(bjHand.GetCard(1))}].");
				Console.WriteLine($"Got - [{bjHand.IndexOf(1)}].");
				Console.WriteLine($"Got - [{bjHand.IndexOf(bjHand.GetCard(1).Suit, bjHand.GetCard(1).Value)}].");
			}

			static void DisplayCardAttributes() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[convert its attributes to a string for displaying on the screen]");
				Console.WriteLine($"Init - [{bjHand}].");
				Console.WriteLine("Expected - Three various class properties and their returned values.");
				Console.Write("Got - [");
				for (var i = 0; i < TypeDescriptor.GetProperties(bjHand).Count; i++) {
					if (i == 0) Console.WriteLine();
					Console.Write($"{TypeDescriptor.GetProperties(bjHand)[i].Name} = {TypeDescriptor.GetProperties(bjHand)[i].GetValue(bjHand)}\n");
				}
				Console.WriteLine("].");
			}
		}

		static void Program2() {
			// determine if it has an ace or not
			CheckIfHasAce();
			Console.WriteLine("\n");
			// get its score
			GetScore();
			Console.WriteLine("\n");
			// determine if it is busted (its score is greater than 21) or not
			CheckIfBusted();
			Console.WriteLine("\n");

			static void CheckIfHasAce() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 2);

				Console.WriteLine("[determine if it has an ace or not]");
				Console.WriteLine($"Init - [\n{bjHand}].");
				Console.WriteLine($"Expected - [True] or [False] value depending on whether the blackjack hand contains an Ace card.");
				Console.WriteLine($"Got - [{bjHand.HasAce}].");
			}

			static void GetScore() {
				Deck d = new();

				d.Shuffle();

				BJHand bjHand = new(d, 21);

				Console.WriteLine("[get its score]");
				Console.WriteLine($"Init - [\n{bjHand}].");
				Console.WriteLine($"Expected - The sum total of card values.");
				Console.WriteLine($"Got - [{bjHand.Score}].");
			}

			static void CheckIfBusted() {
				Deck d = new();
				BJHand bjHand1 = new(d, 21);

				d.Shuffle();

				BJHand bjHand2 = new(d, 42);

				Console.WriteLine("[determine if it is busted (its score is greater than 21) or not]");
				Console.WriteLine($"Init 1 - [\n{bjHand1}].");
				Console.WriteLine($"Expected - [False].");
				Console.WriteLine($"Got - [{bjHand1.IsBusted}].");
				Console.WriteLine($"Init 2 - [\n{bjHand2}].");
				Console.WriteLine($"Expected - [True].");
				Console.WriteLine($"Got - [{bjHand2.IsBusted}].");
			}
		}

		static void Program3(int scorePlayer = 0, int scoreDealer = 0) {
			//if (scorePlayer != 0 && scoreDealer != 0) Console.WriteLine("\n");

			//Deck d = new();
			//BJHand player = new(d, 4);

			//d.Shuffle();

			//BJHand dealer = new(d, 4);

			//Console.WriteLine("[Is the player's hand greater than the dealer's hand]");
			//Console.WriteLine($"\n\nPlayer's hand - [\n{player}].");
			//Console.WriteLine($"\n\nDealer's hand - [\n{dealer}].");
			//Console.WriteLine($"\n\nPlayer's total - [{player.Score}].");
			//Console.WriteLine($"\n\nDealer's total - [{dealer.Score}].");

			//if (player.Score > dealer.Score) {
			//	scorePlayer++;
			//	Console.WriteLine("\n\nYou won! Your hand's score was the same as the dealer's score.");
			//	PlayAgain(scorePlayer, scoreDealer);
			//}
			//else if (player.Score >= 17) {
			//	Console.WriteLine("\n\nYou lost... Your hand's score was higher then or equal to the value, 17.");

			//	PlayAgain(scorePlayer, scoreDealer);
			//}
			//else if (player.Score <= 16) {
			//	Console.WriteLine("\n\nPlay again?. Your hand's score was lower then or equal to the value, 16.");
			//	Console.Write("\n\nENTER \"HIT\" to add more card (or) \"STOP\" to stop: ");
			//	string promptHIt = Console.ReadLine();
			//	if (promptHIt == "hit" || promptHIt == "HIT") {
			//		Card c = new();

			//		player.AddCard(c);

			//		Console.WriteLine($"\n\nPlayer's total - [{player.Score}].");
			//		PlayAgain(scorePlayer, scoreDealer);
			//	}
			//}

			//static void PlayAgain(int scorePlayer, int scoreDealer) {
			//	Console.WriteLine("\n\nPlay again? ENTER [Y]\\[N]: ");

			//	string promptAgain = Console.ReadLine();

			//	if (promptAgain == "y" || promptAgain == "Y") Program3(scorePlayer, scoreDealer);

			//	Console.WriteLine();

			//	Environment.Exit(0);
			//}
		}

		static void Main() {
			Program1();
			Program2();
			//Program3();
		}
	}
}