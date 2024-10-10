//Console.Write("Iveskite savaites dienos skaiciu (1 - 7): ");
//int input = Convert.ToByte(Console.ReadLine());

//string result = input switch
//{
//    1 => "Pirmadienis",
//    2 => "Antradienis",
//    3 => "Treciadienis",
//    4 => "Ketvirtadienis",
//    5 => "Penktadienis",
//    6 => "Sestadienis",
//    7 => "Sekmadienis",
//    _ => "Incorrect input!"
//};
//Console.WriteLine(result);



//Console.Write("Iveskite savo amziu: ");
//int input = Convert.ToByte(Console.ReadLine());

//string result = input switch
//{
//    > 7 and <= 18 => "Moksleivis",
//    > 18 and <= 25 => "Studentas",
//    > 25 and <= 65 => "Darbuotojas",
//    > 65 => "Pensininkas",
//    _ => "Out of range"
//};
//Console.WriteLine(result);



//Console.Write("Iveskite menesi (1 - 12): ");
//int input = Convert.ToByte(Console.ReadLine());

//string result = input switch
//{
//    1 => "01",
//    2 => "02",
//    3 => "03",
//    4 => "04",
//    5 => "05",
//    6 => "06",
//    7 => "07",
//    8 => "08",
//    9 => "09",
//    10 => "10",
//    11 => "11",
//    12 => "12",
//    _ => "Out of range"
//};
//Console.WriteLine(result);



using System.Threading.Channels;

Console.Write("Iveskite figuros pavadinima (kvadratas, staciakampis, apskritimas): ");
string input = Console.ReadLine();

switch (input)
{
    case "kvadratas":
        Console.Write("Iveskite krastines ilgi: ");
        int i = Convert.ToByte(Console.ReadLine());
        Console.WriteLine($"Figuros plotis yra: {Math.Pow(i, 2)}");
        break;
    case "staciakampis":
        Console.Write("Iveskite pirmos krastines ilgi: ");
        i = Convert.ToByte(Console.ReadLine());
        Console.Write("Iveskite antros krastines ilgi: ");
        int p = Convert.ToByte(Console.ReadLine());
        Console.WriteLine($"Figuros plotis yra: {i * p}");
        break;
    case "apskritimas":
        Console.Write("Iveskite apskritimo radiusa: ");
        int radius = Convert.ToByte(Console.ReadLine());
        Console.WriteLine($"Figuros plotis yra: {Math.PI * Math.Pow(radius, 2)}");
        break;
}

