using Protmusis;

while (!Methods.quitGame)
{
    Methods.Login();

    while (!Methods.logOut && !Methods.quitGame)
    {
        Methods.LoggedPlayerMenu(Methods.currentUser, Methods.userScore);

        Methods.GetUserChoice(1, 5);
        switch (Methods.userChoice)
        {
            case 1:
                Methods.Logout();
                break;
            case 2:
                Methods.GameRules();
                break;
            case 3:
                Methods.ReviewResults();
                break;
            case 4:
                while (Methods.userChoice != 113 && !Methods.quitGame)
                {
                    Methods.StartQuiz();
                    if (Methods.questions.Count == 0)
                    {
                        Console.WriteLine("All questions in this category completed!");
                        break;
                    }
                }
                Methods.UserScoreUpdate();
                break;
            case 5:
                Methods.QuitGame();
                break;
        }
    }
}

