//int[] ints = { 1, 2, 3 };
//int[] intsSquare = new int[ints.Length];

//for (int i = 0; i < ints.Length; i++)
//{
//    intsSquare[i] = ints[i] * ints[i];
//    Console.WriteLine(intsSquare[i]);
//}



//Console.WriteLine("Input an array values:");
////string input = Console.ReadLine();
//string input = "1 2 3 4 5";
//Console.WriteLine($"Sum of the INT array elements is: {Methods.ArrESum(input)}");


//int[] intArr = { 111, 2222, 5, 99, 888 };
//Console.WriteLine(Methods.MaxValue(intArr));

//Methods.ArrReverse(intArr);

//Console.WriteLine(Methods.GetChars("Labas"));

//string str = "Labas mano vardas yra.";
//Console.WriteLine(Methods.GetFirstChar(str));
//Console.WriteLine(Methods.GetLastChar(str));



int[] numbers = { 1, 22, 3, 44, 5 };
for (int i = 1; i < numbers.Length; i++)
{
    for (int j = 0; j < i; j++)
    {
        int el = numbers[j];

        //if (numbers[i] < numbers[j])
        if (numbers[i] > numbers[j])
        {
            numbers[j] = numbers[i];
            numbers[i] = el;
        }
    }
}

foreach (int item in numbers)
{
    Console.WriteLine(item);
}



public static class Methods
{
    public static int ArrESum(string str)
    {
        int sum = 0;
        int num = 0;
        string[] strArr = str.Split(',', ' ');
        for (int i = 0; i < strArr.Length; i++)
        {
            int.TryParse(strArr[i], out num);
            sum += num;
        }
        return sum;
    }



    public static int MaxValue(int[] ints)
    {
        int maxValue = 0;
        for (int i = 0; i < ints.Length; i++)
        {
            if (i == 0)
            {
                maxValue = ints[i];
            }

            if (ints[i] > maxValue)
            {
                maxValue = ints[i];
            }
        }
        return maxValue;
    }



    public static void ArrReverse(int[] ints)
    {
        for (int i = ints.Length - 1; i >= 0; i--)
        {
            Console.Write($"{ints[i]} ");
        }
    }



    public static char[] GetChars(string str)
    {
        return str.ToCharArray();
    }



    public static char GetFirstChar(string str)
    {
        char[] chars = str.Trim().ToCharArray();
        return chars[0];
    }

    public static char GetLastChar(string str)
    {
        char[] chars = str.Trim().ToCharArray();
        return chars[chars.Length - 2];
    }
}
