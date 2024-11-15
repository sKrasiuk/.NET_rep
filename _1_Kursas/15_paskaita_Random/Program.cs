//Console.WriteLine(Methods.RandBool());
//Console.WriteLine(Methods.RandomStringGen(20));
//Console.WriteLine(Methods.RandomSum());
Methods.UserGuess();


public static class Methods
{
    private static readonly Random random = new Random();

    public static bool RandBool()
    {
        int x = random.Next(0, 2);
        if (x != 0)
        {
            return true;
        }
        return false;
    }

    public static string RandomStringGen(int value)
    {
        //int randVal = random.Next(65, 91);
        var randPass = new char[value];

        for (int i = 0; i < randPass.Length; i++)
        {
            randPass[i] = (char)random.Next(65, 91);
        }

        return new string(randPass);
    }

    public static int sum;
    public static int RandomSum()
    {
        for (int i = 0; i < 100; i++)
        {
            sum += random.Next(1, 7);
        }
        return sum;
    }

    public static int randomNum;
    public static int RandomIntGen() // generates 1 - 100
    {
        randomNum = random.Next(1, 101);
        return randomNum;
    }

    public static void UserGuess()
    {
        RandomIntGen();
        Console.Clear();
        Console.WriteLine("""
            Guess is the random number less or greater than 50.
            Input Y / N

            """);
        string userInput = Console.ReadLine().ToLower().Trim();

        if (userInput == "y" && randomNum > 50)
        {
            Console.WriteLine($"Correct! the number is greater than 50.    Number generated: {randomNum}");
        }
        else if (userInput == "n" && randomNum > 50)
        {
            Console.WriteLine($"Incorrect! the number is greater than 50.    Number generated: {randomNum}");
        }
        else if (userInput == "n" && randomNum < 50)
        {
            Console.WriteLine($"Correct! the number is less than 50.    Number generated: {randomNum}");
        }
        else
        {
            Console.WriteLine($"Incorrect! the number is less than 50.    Number generated: {randomNum}");
        }
    }
}