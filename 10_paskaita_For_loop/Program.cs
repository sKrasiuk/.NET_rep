//for (int i = 2; i <= 100; i += 2)
//{
//    Console.WriteLine(i);
//}

//Console.Write("Input a number: ");
//int.TryParse(Console.ReadLine().Trim(), out int userInput);
//int res = 0;
//for (int i = 1; i <= userInput; i++)
//{
//    res += i;
//}
//Console.WriteLine($"Result: {res}");

//Console.Write("Input a number: ");
//int.TryParse(Console.ReadLine().Trim(), out int userInput);
//for (int i = 1; i <= userInput; i++)
//{
//    Console.WriteLine(Math.Pow(i, 2));
//}

//Console.Write("Input a number: ");
//int.TryParse(Console.ReadLine().Trim(), out int userInput);
//double res = 0;
//for (int i = 0; i <= userInput; i++)
//{
//    res += i;
//}
//double fRes = res / userInput;
//Console.WriteLine($"Result: {fRes}");

//Console.Write("Input a number: ");
//int.TryParse(Console.ReadLine().Trim(), out int userInput);
//for (int i = 0; i < userInput; i++)
//{
//	Console.WriteLine("*");
//}

Console.Write("Input a number: ");
int.TryParse(Console.ReadLine().Trim(), out int userInput);
for (int i = 1; i <= userInput; i++)
{
    for (int j = i; j % 3 == 0; j++)
    {
        Console.WriteLine(j);
    }
}