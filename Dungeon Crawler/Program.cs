
Methods.RoadsCrossing();

do
{
    if (Methods.EventsRandomizer() == 5)
    {
        Methods.PathChoise();
    }
    else
    {
        switch (Methods.ScenarioChoise())
        {
            case 1:
                Methods.Run();
                break;

            case 2:
                if (Methods.Fight())
                {
                    Methods.WinOrLose();
                }
                else
                {
                    Methods.WinOrLose();
                }

                break;
        }
    }
} while (Methods.WinOrLose());



