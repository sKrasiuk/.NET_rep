//int i = 1;
//while (i < 6)
//{
//    Console.WriteLine(i);
//    i++;
//}



//int j = 5;
//while (j > 0)
//{
//    Console.WriteLine(j);
//    j--;
//}



//int k = 1;
//while (k < 11)
//{
//    if (k % 2 == 0)
//    {
//        Console.WriteLine(k);
//    }
//    k++;
//}



//int i = 10;
//while (i > 0)
//{
//    if (i % 3 == 0)
//    {
//        Console.WriteLine(i);
//    }
//    if (i == 1)
//    {
//        Console.WriteLine(i);
//    }
//    i--;
//}


//bool repeat = true;

//while (repeat)
//{
//    Console.Write("Please input a number: ");
//    string input = Console.ReadLine();
//    if (int.TryParse(input, out int res))
//    {
//        if (res < 101 && res > 0)
//        {
//            Console.WriteLine(res);
//            repeat = false;
//        }
//    }
//}



int parseResult;
do
{
    Console.Write("Please input a number to calculate it's factorial: ");
    string userInput = Console.ReadLine();
    int.TryParse(userInput, out parseResult);

    int sum = 1;
    for (int i = parseResult; i > 0; i--)
    {
        sum *= i;
    }
    Console.WriteLine(sum);
} while (parseResult >= 0);
