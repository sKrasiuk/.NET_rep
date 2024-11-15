//int n1 = 10;
//int n2 = 5;
//Console.WriteLine($"n1 = {n1}");
//Console.WriteLine($"n2 = {n2}");
//Console.WriteLine();
//Methods.Swap(ref n1, ref n2);
//Console.WriteLine($"n1 = {n1}");
//Console.WriteLine($"n2 = {n2}");
//Console.WriteLine();

//int num = 10;
//Console.WriteLine("Input an increment number:");
//int.TryParse(Console.ReadLine().Trim(), out int num2);
//Console.WriteLine(Methods.IncrementByN(ref num, num2));
//Console.WriteLine();

//string str = "   hello   ";
//Console.WriteLine(Methods.TrimAndCapitalize(ref str));

//Methods.GetUserData(out string vardas, out string pavarde);
//Console.WriteLine($"vardas: {vardas}, pavarde: {pavarde}");

Console.WriteLine("Input first number: ");
double.TryParse(Console.ReadLine().Trim(), out double num1);
Console.WriteLine("Input second number: ");
double.TryParse(Console.ReadLine().Trim(), out double num2);
Methods.Divide(num1, num2, out double dalmen, out double reminder);
Console.WriteLine($"Dalmem: {dalmen}, Reminder {reminder}");


public static class Methods
{
    //public static void Swap(ref int x, ref int y)
    //{
    //    int save = x;
    //    x = y;
    //    y = save;
    //}

    //public static int IncrementByN(ref int x, int y)
    //{
    //    return x + y;
    //}

    //public static string TrimAndCapitalize(ref string str)
    //{
    //    string newStr = str.Trim();
    //    return char.ToUpper(newStr[0]) + newStr.Substring(1);
    //}

    //public static void GetUserData(out string v, out string p)
    //{
    //    v = Console.ReadLine().Trim();
    //    p = Console.ReadLine().Trim();
    //}

    public static void Divide(double num1, double num2, out double dalmen, out double reminder)
    {
        double result = num1 / num2;
        reminder = num1 % num2;
        dalmen = (int)result;
    }
}

