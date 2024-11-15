//var strList = new List<string>() { "labas", "paradoksas", "keistas" };
//Methods.PrintItemLength(strList);

var intList = new List<int>(new int[20]);
Methods.RandomListFiller(intList);

Methods.CreateListOfIntsGreaterThanTen(intList);


public static class Methods
{
    private static readonly Random random = new Random();
    public static void PrintItemLength(List<string> strings)
    {
        foreach (var item in strings)
        {
            Console.WriteLine(item.Length);
        }
    }

    public static void RandomListFiller(List<int> ints)
    {
        for (int i = 0; i < ints.Capacity; i++)
        {
            ints[i] = random.Next(20);
        }
    }

    public static List<int> CreateListOfIntsGreaterThanTen(List<int> ints)
    {
        var listGreaterThanTen = new List<int>();
        foreach (var item in ints)
        {
            if (item > 10)
            {
                listGreaterThanTen.Add(item);
            }
        }
        return listGreaterThanTen;
    }
}