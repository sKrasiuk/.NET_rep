//using System.Net.Quic;

//int a = 10;
//int b = 5;
//int c = 8;

//int max = a;
//if (b > max)
//{
//    max = b;
//}
//if (c > max)
//{
//    max = c; // klaida
//}
//Console.WriteLine("The maximum value is: " + max);



//string firstName = "John";
//string lastName = "Doe";
//string fullName = firstName +" "+ lastName; // klaida
//Console.WriteLine("Full Name: " + fullName);



//int counter = 0;
//while (counter <= 10)
//{
//    Console.WriteLine("Count: " + counter);
//    counter++; // klaida
//}



//int i = 1;
//while (i <=5) // klaida
//{
//    Console.WriteLine(i);
//    i++;
//}



//string name1 = "John";
//string name2 = "john";
//if (name1.ToLower().Equals(name2.ToLower())) // klaida
//{
//    Console.WriteLine("Names are the same.");
//}
//else
//{
//    Console.WriteLine("Names are different.");
//}



using System.Text;

//Console.WriteLine("Input a string of your choise:");
//string str = Console.ReadLine();

//StringBuilder stringBuilder = new StringBuilder();
//for (int i = str.Length - 1; i >= 0; i--)
//{
//    stringBuilder.Append(str[i]);
//}
//Console.WriteLine(stringBuilder.ToString());



//Console.WriteLine("Input a string of your choise:");
//string str = Console.ReadLine();
string str = "laaaabas vakaras";

StringBuilder sb = new StringBuilder(str);
StringBuilder sbShort = new StringBuilder();
for (int i = 0; i < sb.Length; i++)
{
    bool isDuplicate = false;
    for (int j = 0; j < sbShort.Length; j++)
    {
        if (sbShort[j] == sb[i])
        {
            isDuplicate = true;
            break;
        }
    }

    if (!isDuplicate)
    {
        sbShort.Append(sb[i]);
    }
}
Console.WriteLine(sbShort.ToString());
