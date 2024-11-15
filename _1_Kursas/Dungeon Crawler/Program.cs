Methods.PlayerName();
Methods.TheBeginning();

do
{
    Methods.EventsRandomizer();
    if (Methods.eventRandomizerResult == 5)
    {
        Methods.PathChoice();
    }
    else
    {
        Methods.ScenarioChoise();
        switch (Methods.scenarioChoise)
        {
            case 1:
                Methods.Run();
                break;

            case 2:
                Methods.IsWinOrLose(Methods.Fight());
                break;
        }
    }

} while (!Methods.IsGameOn(Methods.isDefeated) && !Methods.HasEscapedTheDungeon(Methods.hasEscaped));
