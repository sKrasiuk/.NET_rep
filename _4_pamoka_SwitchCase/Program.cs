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

Console.WriteLine("""
     Pasirinkite figura (1 - 3):
     1: kvadratas
     2: staciakampis 
     3: apskritimas
     """);
Console.WriteLine();
int input = Convert.ToByte(Console.ReadLine());
bool repeat = true;


switch (input)
{
while (repeat)
        case 1:
        Console.Write("Iveskite krastines ilgi: ");
        int i = Convert.ToByte(Console.ReadLine());
        Console.WriteLine($"Kvadrato plotis yra: {Math.Pow(i, 2)}");
        repeat = false;
        break;
    case 2:
        Console.Write("Iveskite pirmos krastines ilgi: ");
        i = Convert.ToByte(Console.ReadLine());
        Console.Write("Iveskite antros krastines ilgi: ");
        int p = Convert.ToByte(Console.ReadLine());
        Console.WriteLine($"Staciakampio plotis yra: {i * p}");
        repeat = false;
        break;
    case 3:
        Console.Write("Iveskite apskritimo radiusa: ");
        int radius = Convert.ToByte(Console.ReadLine());
        Console.WriteLine($"Apskritimo plotis yra: {Math.PI * Math.Pow(radius, 2)}");
        repeat = false;
        break;
        {

        }
    default:
        Console.Write("Incorrect input value! Please input 1 - 3:");
        break;
    }





