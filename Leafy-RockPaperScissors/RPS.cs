// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the LeafyCoding INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Leafy-RockPaperScissors INC. All rights reserved.
// -----------------------------------------------------------

#region

using System;
using System.Threading;

#endregion

namespace Leafy_RockPaperScissors
{
    internal static class RPS
    {
        private static string player1 = string.Empty;
        private static int score1;
        private static string player2 = string.Empty;
        private static int score2;

        private static void Main()
        {
            Console.Title = "Leafy RPS 🍂";

            Console.WriteLine("Player 1 name?");
            player1 = Console.ReadLine();

            Console.WriteLine("Player 2 name?");
            player2 = Console.ReadLine();

            Thread.Sleep(1000);
            Console.Clear();

            while (true)
            {
                Play();

                Tools.ColoredWrite(ConsoleColor.DarkGray, "=== Round ended.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void Play()
        {
            var choice1 = string.Empty;
            bool choice1valid;
            do
            {
                Console.WriteLine($"{player1}'s turn:");
                var _choice1 = Console.ReadKey(true);
                switch (_choice1.Key)
                {
                    case ConsoleKey.NumPad1:
                        choice1 = "P";
                        choice1valid = true;
                        break;
                    case ConsoleKey.NumPad2:
                        choice1 = "F";
                        choice1valid = true;
                        break;
                    case ConsoleKey.NumPad3:
                        choice1 = "C";
                        choice1valid = true;
                        break;
                    default:
                        Tools.ColoredWrite(ConsoleColor.Red, "Invalid choice.");
                        choice1valid = false;
                        break;
                }
            } while (!choice1valid);

            var choice2 = string.Empty;
            bool choice2valid;
            do
            {
                Console.WriteLine($"{player2}'s turn:");
                var _choice2 = Console.ReadKey(true);

                switch (_choice2.Key)
                {
                    case ConsoleKey.Z:
                        choice2 = "P";
                        choice2valid = true;
                        break;
                    case ConsoleKey.X:
                        choice2 = "F";
                        choice2valid = true;
                        break;
                    case ConsoleKey.C:
                        choice2 = "C";
                        choice2valid = true;
                        break;
                    default:
                        Tools.ColoredWrite(ConsoleColor.Red, "Invalid choice.");
                        choice2valid = false;
                        break;
                }
            } while (!choice2valid);

            var winner = string.Empty;

            switch (choice1)
            {
                case "P":
                    switch (choice2)
                    {
                        case "P":
                            winner = $"{player1}: Rock;{player2}: Rock;Tied";
                            break;
                        case "F":
                            winner = $"{player1}: Rock;{player2}: Paper;{player2} wins.";
                            score2++;
                            break;
                        case "C":
                            winner = $"{player1}: Rock;{player2}: Scissors;{player1} wins.";
                            score1++;
                            break;
                    }
                    break;
                case "F":
                    switch (choice2)
                    {
                        case "P":
                            winner = $"{player1}: Paper;{player2}: Rock;{player1} wins.";
                            score1++;
                            break;
                        case "F":
                            winner = $"{player1}: Paper;{player2}: Paper;Tied";
                            break;
                        case "C":
                            winner = $"{player1}: Paper;{player2}: Scissors;{player2} wins.";
                            score2++;
                            break;
                    }
                    break;
                case "C":
                    switch (choice2)
                    {
                        case "P":
                            winner = $"{player1}: Scissors;{player2}: Rock;{player2} wins.";
                            score2++;
                            break;
                        case "F":
                            winner = $"{player1}: Scissors;{player2}: Feuille;{player1} wins.";
                            score1++;
                            break;
                        case "C":
                            winner = $"{player1}: Scissors;{player2}: Scissors;Tied";
                            break;
                    }
                    break;
            }

            var split = winner.Split(';');
            Console.Title = $"Leafy RPS 🍂 - {player1}: {score1} | {player2}: {score2}";
            Console.WriteLine("===================================");
            Tools.ColoredWrite(ConsoleColor.Cyan, split[0]);
            Tools.ColoredWrite(ConsoleColor.Cyan, split[1]);
            Tools.ColoredWrite(ConsoleColor.Green, split[2]);
            Console.WriteLine("===================================");
            Console.WriteLine();
        }
    }
}