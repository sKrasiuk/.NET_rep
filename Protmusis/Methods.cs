using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protmusis
{
    internal class Methods
    {
        private static readonly Random random = new();

        private static string UserInput(int minStringLength = 1)
        {
            string userInput = "";
            do
            {
                userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "exit")
                {
                    QuitGame();
                }
            } while (string.IsNullOrEmpty(userInput) || userInput.Length < minStringLength);

            return userInput;
        }

        public static string currentUser;
        public static void Login()
        {
            logOut = false;
            userScore = 0;
            string name, surname;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Input \"exit\" to quit the game\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello player!");
            Console.ResetColor();

            Console.Write("\nPlease input your name: ");
            name = UserInput(3);

            if (quitGame) return;

            name = char.ToUpper(name[0]) + name.Substring(1);

            Console.Write("Please input your surname: ");
            surname = UserInput(3);

            if (quitGame) return;

            surname = char.ToUpper(surname[0]) + surname.Substring(1);

            currentUser = $"{name} {surname}";
        }

        public static bool logOut = false;
        public static void Logout()
        {
            currentUser = null;
            logOut = true;
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
            else
            {
                playersDB[currentUser] = userScore;
            }
        }

        private static Dictionary<string, int> playersDB = new();
        public static void LoggedPlayerMenu(string key, int value)
        {
            if (!playersDB.ContainsKey(key))
            {
                Console.Clear();
                playersDB.Add(key, value);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCongratulations on signing in and welcome to the game {0}!", currentUser);
                Console.ResetColor();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCurrent player: {0}!", currentUser);
                Console.ResetColor();
            }

            MainMenu();
        }

        private static void MainMenu()
        {
            Console.WriteLine("""
                
                1: Logout
                2: Game rules
                3: Participants and game results
                4: Start the quiz
                5: Quit the game (or input "exit")

                """);
        }

        public static int userChoice;
        public static void GetUserChoice(int minValue = 113, int maxValue = 113)
        {
            userChoice = 0;
            bool isValid = false;

            Console.Write("\nInput your choice: ");
            do
            {
                string input = UserInput();

                if ((int)input[0] == 113) // value 113 = ASCII 'q'
                {
                    isValid = true;
                    userChoice = 113;
                }
                else if (input == "exit")
                {
                    isValid = true;
                    //QuitGame();
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

            GoBackToMainMenu();
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

            GoBackToMainMenu();
        }

        public static bool quitGame = false;
        public static void QuitGame()
        {
            quitGame = true;
        }

        private static void GoBackToMainMenu()
        {
            Console.ResetColor();
            Console.WriteLine("\nInput 'q' to go back or \"exit\" to quit the game");
            GetUserChoice();
        }

        private static Dictionary<string, string> capitals = new()
        {
            {"What is the capital of France?", "Paris"},
            {"What is the capital of Japan?", "Tokyo"},
            {"What is the capital of Australia?", "Canberra"},
            {"What is the capital of Brazil?", "Brasília"},
            {"What is the capital of Canada?", "Ottawa"},
            {"What is the capital of Italy?", "Rome"},
            {"What is the capital of India?", "New Delhi"},
            {"What is the capital of Germany?", "Berlin"},
            {"What is the capital of Egypt?", "Cairo"},
            {"What is the capital of Russia?", "Moscow"},
            {"What is the capital of Mexico?", "Mexico City"},
            {"What is the capital of South Africa?", "Pretoria"},
            {"What is the capital of the United Kingdom?", "London"},
            {"What is the capital of Argentina?", "Buenos Aires"},
            {"What is the capital of Saudi Arabia?", "Riyadh"},
        };

        private static Dictionary<string, string> rivers = new()
        {
            {"Which river flows through Paris?", "Seine"},
            {"Which river is the longest in the world?", "Nile"},
            {"Which river flows through Egypt and is known as the lifeblood of the country?", "Nile"},
            {"Which river is famously associated with the city of London?", "Thames"},
            {"Which river is the longest in South America?", "Amazon"},
            {"Which river runs through the Grand Canyon in the United States?", "Colorado River"},
            {"What is the longest river in China?", "Yangtze River"},
            {"Which river forms part of the border between the United States and Mexico?", "Rio Grande"},
            {"Which river flows through Rome, Italy?", "Tiber"},
            {"Which river flows through the rainforests of central Africa and is the second longest in Africa?", "Congo River"},
            {"Which river flows through Budapest, Hungary?", "Danube"},
            {"Which river flows through Moscow, Russia?", "Moskva"},
            {"Which river is associated with New York City, USA?", "Hudson River"},
            {"Which river flows through the cities of Vienna, Bratislava, and Belgrade?", "Danube"},
            {"Which river flows across northern India and is sacred in Hinduism?", "Ganges"},
        };

        private static Dictionary<string, string> mountains = new()
        {
            {"What is the highest mountain in the world?", "Mount Everest"},
            {"Which mountain is the tallest in Tanzania?", "Mount Kilimanjaro"},
            {"Which mountain is the highest in North America?", "Mount Denali"},
            {"Which mountain range forms a natural border between Europe and Asia?", "Ural Mountains"},
            {"What is the tallest mountain in Africa?", "Mount Kilimanjaro"},
            {"What is the highest mountain in South America?", "Mount Aconcagua"},
            {"Which mountain is considered the second highest in the world?", "K2"},
            {"Which mountain range is located in the western United States?", "Rocky Mountains"},
            {"Which mountain range runs along the west coast of South America?", "Andes Mountains"},
            {"What is the tallest mountain in the Alps?", "Mount Blanc"},
            {"Which famous Japanese mountain is an active volcano?", "Mount Fuji"},
            {"What is the longest mountain range on Earth?", "Andes Mountains"},
            {"Which mountain is the highest peak in Antarctica?", "Vinson Massif"},
            {"Which Himalayan peak is known as the \"Matterhorn of the Himalayas\" due to its distinct shape?", "Ama Dablam"},
            {"Which U.S. mountain erupted in 1980, causing significant destruction?", "Mount Saint Helens"},
        };

        private static List<Dictionary<string, string>> categories = new()
        {
            capitals,
            rivers,
            mountains
        };

        private static List<string> categoriesNames = new List<string> { "Capitals", "Rivers", "Mountains" };
        public static List<string> questions = new List<string>();
        private static List<string> answers = new List<string>();

        public static void StartQuiz()
        {
            int category = ChooseCategory();
            if (category == 113 || quitGame)
            {
                return;
            }

            GenerateQuestionaryByCategory(category);
            QuestionaryUI();
        }

        public static int ChooseCategory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Choose 1 to 3, or 'q' to return to main menu, \"exit\" to quit the game\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Choose a category to start the quiz:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < categoriesNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {categoriesNames[i]}");
            }

            Console.ResetColor();
            GetUserChoice(1, categoriesNames.Count);

            return userChoice;
        }

        private static void GenerateQuestionaryByCategory(int chosenCategory)
        {
            questions.Clear();
            answers.Clear();
            var category = categories[chosenCategory - 1];

            foreach (var item in category)
            {
                questions.Add(item.Key);
                answers.Add(item.Value);
            }
        }

        private static int indexQA;
        public static void QuestionaryUI()
        {
            int totalQuestions = questions.Count;

            while (questions.Count > 0)
            {
                int remainingQuestions = questions.Count;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Scores: {userScore} | Remaining Questions: {remainingQuestions}/{totalQuestions}\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                indexQA = random.Next(questions.Count);
                correctAnswer = answers[indexQA];
                Console.WriteLine("{0}\n", questions[indexQA]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                List<string> answerOptions = GenerateAnswerOptions(correctAnswer);
                Console.ResetColor();
                Console.Write("\nChoose 1 to 4, or 'q' to return to main menu, \"exit\" to quit the game");
                GetUserChoice(1, 4);

                if (userChoice == 113 || quitGame)
                {
                    return;
                }

                if (answerOptions[userChoice - 1] == correctAnswer)
                {
                    userScore += 1;
                    Console.WriteLine("Correct! Your score is now: {0}", userScore);
                }
                else
                {
                    Console.WriteLine("Incorrect. The correct answer was: {0}", correctAnswer);
                }

                questions.RemoveAt(indexQA);
                answers.RemoveAt(indexQA);

                Console.WriteLine("\nPress any key to continue to the next question...");
                Console.ReadKey();
            }
            Console.WriteLine("\nAll questions in this category completed!");
            GoBackToMainMenu();
        }

        public static string correctAnswer;
        public static List<string> GenerateAnswerOptions(string correctAnswer)
        {
            List<string> answerOptions = new List<string>();
            answerOptions.Add(correctAnswer);

            List<string> remainingAnswers = answers.Where(answer => answer != correctAnswer).ToList();
            remainingAnswers = remainingAnswers.OrderBy(_ => random.Next()).Take(3).ToList();
            answerOptions.AddRange(remainingAnswers);

            while (answerOptions.Count < 4)
            {
                var currentCategory = categories.FirstOrDefault(c => c.ContainsKey(questions[indexQA]));

                if (currentCategory != null)
                {
                    var randomItem = currentCategory.ElementAt(random.Next(currentCategory.Count));

                    if (!answerOptions.Contains(randomItem.Value) && randomItem.Value != correctAnswer)
                    {
                        answerOptions.Add(randomItem.Value);
                    }
                }
            }

            answerOptions = answerOptions.OrderBy(_ => random.Next()).ToList();

            for (int i = 0; i < answerOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {answerOptions[i]}");
            }

            return answerOptions;
        }
    }
}
