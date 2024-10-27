public static class Methods
{
    private static int RandomIntGenerator(int to, int from = 1)
    {
        Random random = new Random();
        int randomNumber = random.Next(from, to);
        return randomNumber;
    }

    private static void SceneMood(int value = default)
    {
        switch (value)
        {
            case 1:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 2:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 3:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 4:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 5:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case 6:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 7:
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            default:
                Console.ResetColor();
                break;
        }
    }

    public static void RoadsCrossing()
    {
        SceneMood(3);
        Console.WriteLine("""
            You have found yourself at the roads crossing.
            There are three ways to go.

            """);
        PathChoise();
    }

    public static void PathChoise()
    {
        string value;
        int choise;

        SceneMood(2);
        do
        {
            Console.WriteLine("""
                Input your choise as a number:
                1: Go left
                2: Go straight
                3: Go right

                """);
            Console.Write("Your choise: ");
            value = Console.ReadLine().Trim();
        } while (!int.TryParse(value, out choise) || choise < 1 || choise > 3);

        Console.Clear();
        //return choise;
    }

    public static int ScenarioChoise()
    {
        string value;
        int choise;

        SceneMood(7);
        do
        {
            Console.WriteLine("""
                Input your choise as number:
                1: Run
                2: Fight

                """);
            Console.Write("Your choise: ");
            value = Console.ReadLine().Trim();
        } while (!int.TryParse(value, out choise) || choise < 1 || choise > 2);

        Console.Clear();
        return choise;
    }

    public static void EventsRandomiser()
    {
        switch (RandomIntGenerator(6))
        {
            case 1:
                SceneMood(6);
                Console.WriteLine("""
                    You’ve found yourself in trouble!
                    A huge minotaur, wielding a massive axe, is staring at you with aggression.
                    You have only a moment to decide your next move!

                    """);
                ScenarioChoise();
                break;
            case 2:
                SceneMood(6);
                Console.WriteLine("""
                    You’ve found yourself in a snake’s nest!
                    An aggressively looking snake isn’t happy to see you and is ready to attack.
                    You need to decide your next step quickly!

                    """);
                ScenarioChoise();
                break;
            case 3:
                SceneMood(6);
                Console.WriteLine("""
                    Have you been eating mushrooms in this cave? Not the best idea!
                    You spot a unicorn waiting for your next move, and it looks unpredictable.
                    That sharp horn is definitely convincing!
                    You have only a moment to decide what to do!

                    """);
                ScenarioChoise();
                break;
            case 4:
                SceneMood(6);
                Console.WriteLine("""
                    Looks like there’s no safe place in this dungeon.
                    You got lucky to encounter a massive ant!
                    It’s staring at you, looking aggressive and clearly unhappy about your presence.
                    You only have a moment to decide your next step!

                    """);
                ScenarioChoise();
                break;
            case 5:
                SceneMood(1);
                Console.WriteLine("""
                    Lucky day for you!
                    Crawling and running through this endless labyrinth, you finally discover a peaceful place to rest.
                    Sunlight filters through a crack in the ceiling, illuminating a small waterfall.
                    Flowers bloom nearby, and butterflies dance in the air. What a perfect spot to restore and relax!

                    """);
                PathChoise();
                break;
        }
    }

    public static void PlayerName(string playerNameInput)
    {
        string playerName = playerNameInput;
    }
}