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



    public static void TheBeginning()
    {
        Console.Clear();
        SceneMood(3);

        Console.WriteLine("""
            You find yourself deep inside a dimly lit dungeon.
            Surrounded by the damp stone walls that seem to whisper secrets of long-forgotten tales.
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

        PathChoice();
    }



    public static void RoadsCrossing()
    {
        Console.Clear();
        SceneMood(3);

        switch (RandomIntGenerator(4))
        {
            case 1:
                Console.WriteLine("""
                    Three paths stretch into the dark before you.
                    To the left, a narrow, mossy tunnel whispers secrets—but perhaps they're better left unheard.
                    The middle path is lined with crumbling statues of warriors, faces twisted in silent agony.
                    Metal clinks softly in the shadows, hinting at something restless.
                    The right path is cold and sharp, the chill of ancient power thick in the air. Ice glitters faintly—something watches, unseen.
                    Three roads, three choices, and only one will lead you to freedom. Which will you dare to take?


                    """);
                break;

            case 2:
                Console.WriteLine("""
                    The flickering torchlight reveals a crossroads deep in the dungeon:
                    three paths diverge, each with a foreboding sense of mystery.
                    The air is thick, and you feel the weight of countless adventurers who’ve likely made this choice before you.
                    You have only one decision—but each road promises a different fate.


                    """);
                break;
            case 3:
                Console.WriteLine("""
                    You reach a crossroad deep in the dungeon, where three dark paths await.
                    To the left, a tight passage drips with murky water, each drop echoing like a heartbeat.
                    A shadow moves, just out of sight.
                    The middle path is wide, lined with shattered stone faces staring blankly from the walls.
                    A low growl rises from the depths, daring you to come closer.
                    To the right, the air turns cold and thin, frost creeping along the ground.
                    The silence here is suffocating—as if even sound fears to enter.
                    Three roads. One choice. Choose wisely, for not all paths lead back.


                    """);
                break;
            case 4:
                Console.WriteLine("""
                    Three paths unfold before you, each shrouded in mystery.
                    To the left, a twisted, narrow tunnel pulses with a faint, eerie light.
                    Soft whispers float up, beckoning you forward.
                    The middle path is littered with shattered bones and broken weapons.
                    A distant, rhythmic thud echoes—a heartbeat, or a warning.
                    To the right, a chilling breeze drifts from the darkness, carrying a metallic scent.
                    Frost laces the walls, and shadows flicker, waiting.
                    Three choices. One fate. Which path will you trust… or regret?


                    """);
                break;
        }

        PathChoice();
    }



    public static void PathChoice()
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
    }


    public static int scenarioChoise;

    public static int ScenarioChoise()
    {
        string value;
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
        } while (!int.TryParse(value, out scenarioChoise) || scenarioChoise < 1 || scenarioChoise > 2);

        Console.Clear();
        return scenarioChoise; ;
    }


    public static int eventRandomizerResult;

    public static int EventsRandomizer()
    {
        Console.Clear();
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
                return eventRandomizerResult = 1;

            case 2:
                Console.WriteLine("""
                    You’ve stumbled into a snake’s nest, and the air is thick with tension.
                    The snake, coiled and ready to strike, eyes you with a fierce intensity that makes your skin crawl.
                    Its scales glisten menacingly, and you can almost hear its hissing voice saying, “You really shouldn’t have come here!”

                    The snake hisses, its tongue flicking out to taste the air, and it looks ready to pounce. What will you do?

                    """);
                return eventRandomizerResult = 2;

            case 3:
                Console.WriteLine("""
                    As you stand there, the effects of the magic mushrooms dance in your mind like a disco party gone rogue.
                    The unicorn, with its shimmering coat and sharp horn, looks both majestic and like it just walked off the cover of a fantasy magazine.
                    You can’t help but chuckle at the absurdity of the situation—after all, who wouldn’t find themselves in a magical cave munching on questionable fungi and facing a unicorn?

                    The unicorn raises an eyebrow, or maybe it’s just the mushrooms playing tricks on you. What will you choose to do?

                    """);
                return eventRandomizerResult = 3;

            case 4:
                Console.WriteLine("""
                    You find yourself deep in the heart of a labyrinthine dungeon, the air thick with the scent of damp earth and a palpable tension.
                    Suddenly, the ground trembles beneath your feet as a massive ant emerges from the shadows, its mandibles snapping menacingly.
                    Its beady eyes lock onto yours, radiating aggression and a primal fury that sends a shiver down your spine.

                    Time seems to freeze as you weigh your options. You can almost hear your heart pounding in your ears.

                    The ant shifts its stance, ready to pounce. The choice is yours, but whatever you decide will echo through the dungeon’s dark halls.
                    What will you do?

                    """);
                return eventRandomizerResult = 4;

            case 5:
                Console.WriteLine("""
                    Lucky day for you!
                    Crawling and running through this endless labyrinth, you finally discover a peaceful place to rest.
                    Sunlight filters through a crack in the ceiling, illuminating a small waterfall.
                    Flowers bloom nearby, and butterflies dance in the air. What a perfect spot to restore and relax!

                    """);
                playerHP = 10;
                return eventRandomizerResult = 5;

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

            if (scenarioChoise == 2)
            {
                IsWinOrLose(Fight());
            }

            runCounter = 0;
        }
        else
        {
            runCounter++;
            RoadsCrossing();
        }
    }



    public static int fightsWonCounter = 0;
    static int playerHP = 10;
    static int opponentHP;
    static int rollWinCounter;
    static int rollLoseCounter;
    static int playerRoll;
    static int opponentRoll;

    public static bool Fight()
    {
        opponentHP = 5;
        rollWinCounter = 0;
        rollLoseCounter = 0;

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
                rollWinCounter++;

                if (opponentHP <= 0 || rollWinCounter >= 3)
                {
                    fightsWonCounter++;
                    return true;
                }
            }
            else if (playerRoll < opponentRoll)
            {
                playerHP--;
                rollLoseCounter++;

                if (playerHP <= 0 || rollLoseCounter >= 5)
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

            //Console.Clear();
            PrintFightInterface();

        } while (playerHP > 0 && rollWinCounter < 3 && opponentHP > 0 && rollLoseCounter < 5);

        return false;
    }



    private static void PrintFightInterface()
    {
        Console.Clear();
        SceneMood(5);
        Console.WriteLine($"""
        Player HP: {playerHP}   Wins in a row: {rollWinCounter}
        Opponent HP: {opponentHP}   Loses in a row: {rollLoseCounter}
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



    public static bool isDefeted = false;

    public static bool IsWinOrLose(bool fightResult)
    {
        Console.Clear();

        if (fightResult)
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
            Console.Clear();

            if (fightsWonCounter < 10)
            {
                hasEscaped = false;

                SceneMood(3);
                Console.WriteLine("""
                You find yourself at the crossroads once more...
                Familiar paths stretch out before you, each whispering promises of adventure and danger."
                "Choose wisely, for your journey is far from over.

                """);

                PathChoice();
            }
            else
            {
                hasEscaped = true;
            }


            return isDefeted = false;
        }
        else
        {
            Console.Clear();
            SceneMood(6);
            Console.WriteLine("""
                You have been DEFEATED...
                Your strength has faltered, and darkness has claimed you.

                GAME OVER!

                The echoes of your journey fade into silence.


                """);
            SceneMood(7);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();

            return isDefeted = true;
        }
    }



    public static bool IsGameOn(bool decision)
    {
        if (decision)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public static bool hasEscaped = false;

    public static bool HasEscapedTheDungeon(bool hasEscaped)
    {
        if (hasEscaped)
        {
            Console.Clear();
            SceneMood(1);
            Console.WriteLine("""
                You stumble forward, each breath ragged, each step heavy.
                The dungeon door creaks open behind you, spilling harsh sunlight onto your battered form.
                The blinding brightness stings, but it’s the sweetest pain you’ve ever felt.
                You blink, trying to focus, to truly believe—**you are free.

                For a moment, the world stands still.
                The haunting sounds of the dungeon echo faintly in your mind—the dripping of unseen water,
                the whispers of the shadows you faced, the rattling of chains that held you captive for so long.
                But it’s over. **You triumphed** against odds that would have felled even the mightiest.
                Every scar, every bruise, every drop of sweat and blood—all have paved the way to this moment.

                Then, the silence breaks.
                Birds call in the distance, and a warm breeze brushes across your face, carrying the scents of freedom: pine, grass, open earth.
                With one last look at the foreboding dungeon behind you, you raise your head, squaring your shoulders.
                **This is not just an escape; it’s a rebirth.**

                **And now?** The world awaits. Your legend has only begun. 

                **What will you conquer next, hero?**


                """);
            SceneMood(4);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();

            return true;
        }

        return false;
    }
}