using _13_paskaita_Foreach_ir_dvimaciai_masyvai;


//int[] numbers = { 2,-5, -3, 7, -9 };


//foreach (var item in Methods.GetPositiveNumbers(numbers))
//{
//    Console.WriteLine(item);
//}

//double[] doubles = { 2, 5, 8};
//Console.WriteLine(Methods.CalculateGPMpayment(doubles));



Console.Write("Input the ammount of Rows: ");
int rows = int.Parse(Console.ReadLine());

Console.Write("Input the ammount of Columns: ");
int columns = int.Parse(Console.ReadLine());

int[,] arr = new int[rows, columns];

for (int i = 0; i < rows; i++)
{
    int valueInput;

    for (int j = 0; j < columns; j++)
    {
        Console.Write("Input a value: ");
        valueInput = int.Parse(Console.ReadLine());
        arr[i, j] = valueInput;
    }
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write(arr[i, j] + "\t");
    }
    Console.WriteLine();
}
