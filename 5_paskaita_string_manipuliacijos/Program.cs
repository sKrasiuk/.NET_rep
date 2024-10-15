//Console.Write("Please input a string: ");
//string input = Console.ReadLine();

//char[] strArray = input.ToCharArray();
//string firstSimb = strArray[0].ToString().ToUpper();
//string restSimb = input.ToString().Substring(1);

//Console.WriteLine(firstSimb + restSimb);



//using System.Security.Claims;

//Console.Write("Please input a string: ");
//char[] input = Console.ReadLine().ToCharArray();

//input[1] = 'g';
//input[3] = 'f';
//input[5] = '*';
//input[7] = 'x';
//input[9] = 'w';

//Console.WriteLine(new string(input));



//bool repeat = true;
//while (repeat)
//{
//    Console.Write("Please input a 5 simbols long string: ");
//    string input = Console.ReadLine();
//    string encodedChar = "";
//    string encodedStr = "";

//    if (input.Length == 5)
//    {
//        Console.Write("How would you like to encode your input? Please enter a number (0 - 9): ");
//        string encodeChar = Console.ReadLine();
//        char[] inputChar = input.ToCharArray();
//        for (int i = 0; i < inputChar.Length; i++)
//        {
//            encodedChar = new string(inputChar[i] + encodeChar);
//            encodedStr += encodedChar;
//        }
//        Console.Write(encodedStr);
//        repeat = false;
//    }
//}



//Console.WriteLine("Please input a sentence: ");
//string input = Console.ReadLine();

//string inputMod = new string(input.Replace("a", "uo").Replace("i", "e"));

//Console.WriteLine(inputMod);



Console.WriteLine("Please input some text: ");
string text = Console.ReadLine();
Console.WriteLine();
Console.Write("Please input a word to replace: ");
string wordReplace = Console.ReadLine();
Console.Write("Please input a replacement word: ");
string replace = Console.ReadLine();

string modText = text.Replace(wordReplace, replace);
Console.WriteLine(modText);