

Dictionary<string, int> persons = new Dictionary<string, int>
{
    {"Petras", 30 },
    {"Jonas", 35},
    {"Antanas", 27 }
};
//Methods.GetDictValues(persons);
Methods.PrintCollection(persons);

var countries = new Dictionary<string, string>
{
    { "Germany", "Berlin"},
    { "Lithuania", "Vilnius"},
    { "Latvia", "Riga"},
    { "Sweden", "Stockholm"}
};
//Console.WriteLine(Methods.GetCapital(Console.ReadLine().Trim(), countries));

var fruits = new Dictionary<string, int>();
Methods.ModifyCollection(persons);
Methods.PrintCollection(persons);


public static class Methods
{
    public static void GetDictValues(Dictionary<string, int> dictionary)
    {
        foreach (var pair in dictionary)
        {
            Console.WriteLine(pair.Key);
            Console.WriteLine(pair.Value);
        }
    }

    public static string GetCapital(string str, Dictionary<string, string> dictionary)
    {
        return dictionary.GetValueOrDefault(str, "No data");
    }

    public static void PrintCollection(Dictionary<string, int> dictionary)
    {
        foreach (var pair in dictionary)
        {
            Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
        }
    }

    public static void ModifyCollection(Dictionary<string, int> dictionary)
    {
        Console.Write("Input a key: ");
        string inputKey = Console.ReadLine().Trim();
        int valueInput;

        if (!dictionary.ContainsKey(inputKey))
        {
            Console.WriteLine("Collection does not contain such item. Item has been added to your collection.");
            Console.Write($"Input a value : ");
            valueInput = int.Parse(Console.ReadLine().Trim());

            dictionary.Add(inputKey, valueInput);
        }
        else
        {
            Console.WriteLine("Collection does contains such item. Item will be updated with a new value.");
            Console.Write($"Input a value : ");
            valueInput = int.Parse(Console.ReadLine().Trim());

            //dictionary.Add(inputKey, valueInput);
            dictionary[inputKey] = valueInput;
        }
    }
}