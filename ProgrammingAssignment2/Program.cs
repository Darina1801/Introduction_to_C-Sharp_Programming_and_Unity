using System;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // print welcome message
            Console.WriteLine("Welcome to Nothing Like BlackJack game app!");
			Console.WriteLine();

            // create and shuffle a deck
			Deck deck = new Deck();
			Console.WriteLine("***shuffling cards***");
			Console.WriteLine();
			deck.Shuffle();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
			Card[,] playersCards = new Card[3, 2];
			Console.WriteLine("**dealing cards**");
			Console.WriteLine();
			for (int i = 0; i < 2; i++)
			{
				for (int y = 0; y < 3; y++)
				{
					playersCards[y, i] = deck.TakeTopCard();
					deck.Cut(0);
				}
			}

			// flip all the cards over
			Console.WriteLine("*fliping cards over*");
			Console.WriteLine();
			foreach (Card card in playersCards)
			{
				if (card.FaceUp != true)
				{
					card.FlipOver();
				}
			}

			// print the cards for player 1
			Console.WriteLine("Player 1 cards are: ");
			int row = 0;
			for (int c = 0; c < 2; c++)
			{
				Console.WriteLine(playersCards[row, c].Rank + " of " + playersCards[row, c].Suit);
			}
			Console.WriteLine();

			// print the cards for player 2
			Console.WriteLine("Player 2 cards are: ");
			row = 1;
			for (int y = 0; y < 2; y++)
			{
				Console.WriteLine(playersCards[row, y].Rank + " of " + playersCards[row, y].Suit);
			}
			Console.WriteLine();

			// print the cards for player 3
			Console.WriteLine("Player 3 cards are: ");
			row = 2;
			for (int y = 0; y < 2; y++)
			{
				Console.WriteLine(playersCards[row, y].Rank + " of " + playersCards[row, y].Suit);
			}
			Console.WriteLine();

			Console.ReadLine();
        }
    }
}
