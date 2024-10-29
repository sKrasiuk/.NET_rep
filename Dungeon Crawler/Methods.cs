public static class Methods
{
    private static readonly Random random = new Random();
    private static int RandomIntGenerator(int to, int from = 1)
    {
        int randomNumber = random.Next(from, to + 1);
        return randomNumber;
    }



    public static void SceneMood(int value = default)
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
        Console.Clear();
        SceneMood(3);
        Console.WriteLine("""
            You find yourself deep inside a dimly lit dungeon, surrounded by the damp stone walls that seem to whisper secrets of long-forgotten tales.
            The air is musty, and the faint echo of dripping water reverberates through the corridors.
            Ahead of you lies a crossroads with three paths, each shrouded in mystery and potential danger.

            To your left, a narrow, winding tunnel snakes deeper into darkness.
            The faint glow of eerie fungi illuminating the way—perhaps a sign of hidden treasures or lurking threats.

            Straight ahead, a wider passage beckons with the faint flicker of torchlight.
            The sounds of distant clanging and murmured voices hint at a gathering of creatures or adventurers, which could either be allies or enemies.

            To your right, a rough-hewn stairway climbs upward, leading to an area that feels warmer, filled with the sound of rushing water.
            It could lead to a hidden chamber or an escape route.

            The dungeon waits for your choice, each path filled with its own possibilities. What will you do?

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



    public static int EventsRandomizer()
    {
        int eventType = (RandomIntGenerator(5));
        SceneMood(eventType == 5 ? 1 : 6);

        switch (eventType)
        {
            case 1:
                Console.WriteLine("""
                    You stand frozen, staring up at the towering minotaur, its muscles rippling beneath its fur and that massive axe glinting ominously in the dim light.
                    The air crackles with tension as it snorts, clearly not pleased to see you intruding on its territory.
                    You can practically hear the theme music for an epic showdown in your head!

                    The minotaur stomps its foot, and the ground shakes. What will you do?

                    """);
                return 1;
            //ScenarioChoise();
            //break;
            case 2:
                Console.WriteLine("""
                    You’ve stumbled into a snake’s nest, and the air is thick with tension.
                    The snake, coiled and ready to strike, eyes you with a fierce intensity that makes your skin crawl.
                    Its scales glisten menacingly, and you can almost hear its hissing voice saying, “You really shouldn’t have come here!”

                    The snake hisses, its tongue flicking out to taste the air, and it looks ready to pounce. What will you do?

                    """);
                return 2;
            //ScenarioChoise();
            //break;
            case 3:
                Console.WriteLine("""
                    As you stand there, the effects of the magic mushrooms dance in your mind like a disco party gone rogue.
                    The unicorn, with its shimmering coat and sharp horn, looks both majestic and like it just walked off the cover of a fantasy magazine.
                    You can’t help but chuckle at the absurdity of the situation—after all, who wouldn’t find themselves in a magical cave munching on questionable fungi and facing a unicorn?

                    The unicorn raises an eyebrow, or maybe it’s just the mushrooms playing tricks on you. What will you choose to do?

                    """);
                return 3;
            //ScenarioChoise();
            //break;
            case 4:
                Console.WriteLine("""
                    You find yourself deep in the heart of a labyrinthine dungeon, the air thick with the scent of damp earth and a palpable tension.
                    Suddenly, the ground trembles beneath your feet as a massive ant emerges from the shadows, its mandibles snapping menacingly.
                    Its beady eyes lock onto yours, radiating aggression and a primal fury that sends a shiver down your spine.

                    Time seems to freeze as you weigh your options. You can almost hear your heart pounding in your ears.

                    The ant shifts its stance, ready to pounce. The choice is yours, but whatever you decide will echo through the dungeon’s dark halls.
                    What will you do?

                    """);
                return 4;
            //ScenarioChoise();
            //break;
            case 5:
                Console.WriteLine("""
                    Lucky day for you!
                    Crawling and running through this endless labyrinth, you finally discover a peaceful place to rest.
                    Sunlight filters through a crack in the ceiling, illuminating a small waterfall.
                    Flowers bloom nearby, and butterflies dance in the air. What a perfect spot to restore and relax!

                    """);
                playerHP = 10;
                return 5;
            //PathChoise();
            //break;
            default:
                Console.WriteLine("An unknown event has occurred!");
                return 0;
        }
    }



    public static void PlayerName(string playerNameInput)
    {
        string playerName = playerNameInput;
    }



    static int runCounter = 0;
    public static void Run()
    {
        if (runCounter == 3)
        {
            do
            {
                SceneMood(5);
                Console.WriteLine("You have no chance to RUN this time!");
            } while (ScenarioChoise() != 2);

            runCounter = 0;
        }
        else
        {
            runCounter++;
            RoadsCrossing();
        }
    }



    static int playerHP = 10;
    static int opponentHP;
    static int winCounter;
    static int loseCounter;
    static int playerRoll;
    static int opponentRoll;
    static bool fightWin;

    public static bool Fight()
    {
        opponentHP = 5;
        winCounter = 0;
        loseCounter = 0;

        Console.Clear();
        SceneMood(5);
        Console.WriteLine("""
            The battle begins with the roll of a die. Both sides rely on luck to determine their fate.

            Victory Conditions:

                * Win three times in a row.
                * Your opponent loses all their HP.

            Defeat Conditions:

                * Lose five times in a row.
                * You lose all your HP.

            Only one will emerge victorious! Good luck!

            """);
        Console.WriteLine("The fate of the battle is in your hands! Press any key to roll the dice..");
        Console.ReadLine();

        do
        {
            playerRoll = RandomIntGenerator(6);
            opponentRoll = RandomIntGenerator(6);

            if (playerRoll > opponentRoll)
            {
                opponentHP--;
                winCounter++;

                if (opponentHP <= 0)
                {
                    return true;
                }
                if (winCounter >= 3)
                {
                    return true;
                }
            }
            else if (playerRoll < opponentRoll)
            {
                playerHP--;
                loseCounter++;

                if (playerHP <= 0)
                {
                    return false;
                }
                if (loseCounter >= 5)
                {
                    return false;
                }
            }
            else
            {
                Console.Clear();
                SceneMood(7);
                Console.WriteLine("It's a draw this round! Both rolled {0}. Press any key to continue...", playerRoll);
                Console.ReadLine();
            }

            PrintFightInterface();

        } while (playerHP > 0 && winCounter < 3 && opponentHP > 0 && loseCounter < 5);

        return false;
    }



    public static void PrintFightInterface()
    {
        Console.Clear();
        SceneMood(5);
        Console.WriteLine($"""
        Player HP: {playerHP}   Wins in a row: {winCounter}
        Opponent HP: {opponentHP}   Loses in a row: {loseCounter}
        """);
        Console.WriteLine();
        Console.WriteLine();
        SceneMood(6);
        Console.WriteLine("You rolled: {0}", playerRoll);
        Console.WriteLine("Opponent rolled: {0}", opponentRoll);
        Console.WriteLine();
        SceneMood(5);
        Console.WriteLine("Press any key to continue ...");
        Console.ReadLine();
    }



    public static bool WinOrLose()
    {
        Console.Clear();

        if (Fight())
        {
            Console.Clear();
            SceneMood(1);
            Console.WriteLine("""
                You have vanquished your opponent...
                The path before you is now clear."
                "Step forth and claim your victory!
                """);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
            SceneMood(3);
            Console.WriteLine("""
                You find yourself at the crossroads once more...
                Familiar paths stretch out before you, each whispering promises of adventure and danger."
                "Choose wisely, for your journey is far from over.

                """);
            PathChoise();

            return true;
        }
        else
        {
            Console.Clear();
            SceneMood(6);
            Console.WriteLine("""
                "You have been defeated...

                Your strength has faltered, and darkness has claimed you."

                "GAME OVER!"

                "The echoes of your journey fade into silence."


                """);
            SceneMood(7);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();

            return false;
        }
    }
}