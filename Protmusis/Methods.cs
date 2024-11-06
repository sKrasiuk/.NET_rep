using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protmusis
{
    internal class Methods
    {
        private static string UserInput(int minStringLength = 1)
        {
            string userInput = "";
            do
            {
                userInput = Console.ReadLine().Trim().ToLower();
            } while (string.IsNullOrEmpty(userInput) || userInput.Length < minStringLength);

            return userInput;
        }

        public static string currentUser;
        public static void Login()
        {
            string name, surname;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello player!");
            Console.ResetColor();
            Console.Write("\nPlease input your name: ");
            name = UserInput(3);
            name = char.ToUpper(name[0]) + name.Substring(1);
            Console.Write("Please input your surname: ");
            surname = UserInput(3);
            surname = char.ToUpper(surname[0]) + surname.Substring(1);
            currentUser = $"{name} {surname}";
        }

        public static void Logout()
        {
            currentUser = null;
            Login();
        }

        public static int userScore;
        public static void UserScoreUpdate()
        {
            if (playersDB.ContainsKey(currentUser))
            {
                if (playersDB[currentUser] < userScore)
                {
                    playersDB[currentUser] = userScore;
                }
            }
        }

        private static Dictionary<string, int> playersDB = new Dictionary<string, int>();
        public static void LoginPlayer(string key, int value)
        {
            if (!playersDB.ContainsKey(key))
            {
                Console.Clear();
                playersDB.Add(key, value);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCongratulations on signing in and welcome to the game {0}!", currentUser);
                Console.ResetColor();
            }
            else// TO BE TESTED LATER
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWelcome back {0}!", currentUser);
                Console.ResetColor();
            }

            GameMenu();
        }

        public static void GameMenu()
        {
            Console.WriteLine("""
                
                1: Logout
                2: Game rules
                3: Participants and game results
                4: Start the game
                5: Quit the game

                """);
        }

        public static int userChoice;
        public static void GetUserChoice(int minValue = 113, int maxValue = 113)
        {
            Console.Write("\nInput your choice: ");
            bool isValid = false;
            do
            {
                string input = UserInput();

                if ((int)input[0] == 113) // value 113 = ASCII 'q'
                {
                    isValid = true;
                    userChoice = 113;
                }
                else
                {
                    isValid = int.TryParse(input, out userChoice) && userChoice >= minValue && userChoice <= maxValue;
                }

            } while (!isValid);
        }

        public static void GameRules()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Rules menu!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("""

                Here are the rules for "The Brainteaser" game:

                Choose a Category:      You will have the option to select from multiple question categories.
                Start the Game:         You will start the game and will have to choose from 4 possible options for the correct answer to the question.
                Answering Questions:    You must choose the option that you believe is the correct answer.
                Scoring:                Points will be awarded for each correct answer, and the total score will be displayed.
                Exit the Game:          You can type 'q' at any time to go back to the main menu.

                """);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Have Fun! The goal is to challenge your knowledge and enjoy the process!");
            Console.ResetColor();
            Console.WriteLine("\nInput 'q' to go back");
            GetUserChoice();
        }

        public static void ReviewResults()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Results menu!\n");
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var pair in playersDB)
            {
                Console.WriteLine("Player: {0}    Scores: {1}", pair.Key, pair.Value);
            }

            Console.ResetColor();
            GetUserChoice();
        }
    }
}
