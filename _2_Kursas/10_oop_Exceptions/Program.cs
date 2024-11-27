//try
//{
//    double x = Convert.ToDouble("str");
//}
//catch (FormatException e)
//{
//    Console.WriteLine("Invalid string format to convert to double: " + e.Message);
//}



//int[] arr = { 1, 2, 3, 4, 5 };
//for (int i = 0; i < arr.Length; i++)
//{
//    Console.WriteLine(arr[i]);
//}

//try
//{
//    Console.WriteLine(arr[7]);
//}
//catch (IndexOutOfRangeException e)
//{
//    Console.WriteLine("No such index in the array: " + e.Message);
//}



using _10_oop_Exceptions;

int[] arr = { 19, 0, 75, 52 };
for (int i = 0; i < arr.Length; i++)
{
    try
    {
        Console.WriteLine(arr[i] / arr[i + 1]);
    }
    catch (DivideByZeroException e)
    {
        Console.WriteLine("Can not divide by zero: " + e.Message);
        continue;
    }
    catch (IndexOutOfRangeException e)
    {
        Console.WriteLine("Index out of range: " + e.Message);
    }
}


ReadFile.ReadF();