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
        SceneMood(4);
        Console.Write("{0}", playerName);
        SceneMood(3);
        Console.WriteLine($"""
            , you stand alone in the heart of a dimly lit dungeon.
            The damp stone walls seem alive, whispering secrets of long-forgotten tales as shadows flicker in the faint light.
            The air is thick and musty, and the slow, rhythmic drip of water echoes through the unseen depths.

            Before you lies a crossroads, with three distinct paths, each shrouded in mystery and potential danger.

            To your left, a narrow, winding tunnel spirals further into darkness. 
            Faintly glowing fungi cling to the walls, illuminating the path ahead—a silent promise of hidden treasures or lurking threats.

            Straight ahead, a wide passage draws you forward, its walls lined with sputtering torches casting long shadows. 
            The sound of clanging metal and distant murmurs drifts toward you, hinting at a gathering—whether of allies or foes remains unclear.

            To your right, a rough-hewn stairway climbs upward, leading toward a warmer light and the sound of rushing water.
            This path could reveal a hidden chamber... or offer a chance to escape the unknown depths below.

            The dungeon holds its breath, awaiting your decision. Which path will you choose?


            """);

        SceneMood(4);
        Console.WriteLine("Press any key to continue ...");
        Console.ReadLine();

        PathChoice();
    }



    public static void RoadsCrossing()
    {
        Console.Clear();
        SceneMood(3);

        switch (RandomIntGenerator(5))
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
            case 5:
                Console.WriteLine("""
                    You find yourself at the crossroads once more...
                    Familiar paths stretch out before you, each whispering promises of adventure and danger."
                    "Choose wisely, for your journey is far from over.
                    

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
                switch (RandomIntGenerator(5))
                {
                    case 1:
                        Console.WriteLine("""
                            Lady Luck shines upon you today!
                            After endless wandering, you stumble upon a hidden alcove.
                            Here, the air is warm and filled with the scent of moss and blooming lilies.
                            A gentle stream flows over smooth stones, creating a crystal-clear pool at its base.
                            Small bioluminescent mushrooms line the edge, casting a soft, magical glow.
                            Fireflies flicker in the air, and a gentle breeze stirs, offering a moment of true calm in this perilous place."


                            """);
                        break;
                    case 2:
                        Console.WriteLine("""
                            At long last, your path leads you to a secluded haven.
                            Here, the walls widen, revealing a tranquil chamber filled with lush greenery.
                            Ferns and soft moss carpet the ground, and a cascade of water spills from a stone crevice high above, filling a shallow, glistening pool.
                            Tiny fish swim lazily beneath the water's surface, and soft light filters through cracks in the stone, casting golden hues across the chamber.
                            In this hidden sanctuary, you find a rare moment to breathe and recharge."


                            """);
                        break;
                    case 3:
                        Console.WriteLine("""
                            As you press onward, a faint sound of trickling water guides you to a small cavern bathed in ethereal light.
                            Overhead, jagged rocks part to reveal a shaft of sunlight, illuminating a field of soft, vibrant moss.
                            Wildflowers in hues of violet and blue thrive here, nestled around a bubbling spring that feeds a small, clear pond.
                            Dragonflies skim across the water's surface, and a gentle mist fills the air, refreshing your senses as you pause in this unexpected paradise."


                            """);
                        break;
                    case 4:
                        Console.WriteLine("""
                            With luck as your guide, you find yourself at the edge of a serene grotto.
                            Thick vines hang from the stone walls, and delicate white flowers bloom along the ground, filling the air with a gentle fragrance.
                            A narrow waterfall flows down from above, creating a soothing sound as it hits the rocks below.
                            In the center, a clear pool reflects the soft light from glowing crystals embedded in the cavern walls.
                            The sense of peace here is undeniable—a rare sanctuary amid the darkness."


                            """);
                        break;
                    case 5:
                        Console.WriteLine("""
                            Fortune smiles upon you!
                            After what feels like an eternity spent crawling through the labyrinth's twisting shadows, you stumble upon a hidden sanctuary.
                            Sunlight spills through a crack in the ceiling, casting a warm glow over the scene—a gentle waterfall tumbles into a clear pool, filling the air with a soothing murmur.
                            Around you, wildflowers bloom in vibrant colors, and butterflies drift lazily through the air, weaving between the blossoms.
                            Here, in this oasis of peace, you’ve found the perfect place to rest, recover, and let your guard down—if only for a moment.


                            """);
                        break;
                }
                playerHP = 10;
                return eventRandomizerResult = 5;

            default:
                Console.WriteLine("An unknown event has occurred!");
                return 0;
        }
    }



    public static string playerName;
    public static void PlayerName()
    {
        Console.Clear();
        SceneMood(3);
        Console.WriteLine("""
            Halt, traveler!

            The shadows shift, and the air grows still as you approach.
            I see the gleam of resolve in your eyes.
            But before you cross this threshold and descend into the forgotten depths, one question remains…

            What is your name, hero?

            
            """);

        SceneMood(4);
        Console.Write("Input your name: ");
        playerName = Console.ReadLine().Trim();
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
        runCounter = 0;
        opponentHP = 5;
        rollWinCounter = 0;
        rollLoseCounter = 0;
        playerRoll = 0;
        opponentRoll = 0;

        Console.Clear();
        SceneMood(5);
        Console.WriteLine("""
            The battle begins with the roll of a die. Both sides rely on luck to determine their fate.

            Victory Conditions:

                * Win three times in a row.
                * Your opponent loses all their HP.

            Defeat Conditions:

                * Lose four times in a row.
                * You lose all your HP.

            Only one will emerge victorious! Good luck!

            """);
        Console.WriteLine("The fate of the battle is in your hands! Press any key to roll the dice..");
        Console.ReadLine();

        do
        {
            PrintFightInterface();
            Console.Clear();

            playerRoll = RandomIntGenerator(6);
            opponentRoll = RandomIntGenerator(6);

            if (playerRoll > opponentRoll)
            {
                opponentHP--;
                rollWinCounter++;
                rollLoseCounter = 0;

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
                rollWinCounter = 0;

                if (playerHP <= 0 || rollLoseCounter >= 4)
                {
                    return false;
                }
            }
            else
            {
                rollWinCounter = 0;
                rollLoseCounter = 0;

                Console.Clear();
                SceneMood(7);
                Console.WriteLine("It's a draw this round! Both rolled {0}. Press any key to continue...", playerRoll);
                Console.ReadLine();
            }

        } while (playerHP > 0 && rollWinCounter < 3 && opponentHP > 0 && rollLoseCounter < 4);

        return false;
    }



    private static void PrintFightInterface()
    {
        Console.Clear();
        SceneMood(5);
        Console.WriteLine($"Enemies defeated: {fightsWonCounter} / 7");
        SceneMood(4);
        Console.WriteLine($"""
        {playerName} HP: {playerHP}   Wins in a row: {rollWinCounter}
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



    public static bool isDefeated = false;

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

            if (fightsWonCounter < 7)
            {
                hasEscaped = false;
                RoadsCrossing();
            }
            else
            {
                hasEscaped = true;
            }


            return isDefeated = false;
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

            return isDefeated = true;
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