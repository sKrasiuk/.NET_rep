//Console.Write("Please input a number: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input > 100)
//{
//    Console.WriteLine("Your input number is greater than a 100");
//}
//else if (input == 100)
//{
//    Console.WriteLine("Your input number is equal 100");
//}
//else 
//{
//    Console.WriteLine("Your input number is less than a 100");
//};



//Console.Write("Please input a day of the week (1 - 7): ");
//int input = Convert.ToInt16(Console.ReadLine());

//switch (input)
//{
//    case 1:
//        Console.WriteLine("Monday");
//        break;
//    case 2:
//        Console.WriteLine("Tuesday");
//        break;
//    case 3:
//        Console.WriteLine("Wednesday");
//        break;
//    case 4:
//        Console.WriteLine("Thursday");
//        break;
//    case 5:
//        Console.WriteLine("Friday");
//        break;
//    case 6:
//        Console.WriteLine("Saturday");
//        break;
//    case 7:
//        Console.WriteLine("Sunday");
//        break;
//    default:
//        Console.WriteLine("Incorrect input value!");
//        break;
//};



//Console.Write("Please input a number: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input % 2 == 0)
//{
//    if (input % 5 == 0 && input % 2 == 0)
//    {
//        Console.WriteLine("Lyginis ir dalinasi is 5";
//    }
//    if (input % 5 == 0)
//    {
//        Console.WriteLine("dalinasi is 5");
//        //{
//        //else
//        //    Console.WriteLine("Lyginis");
//        //}
//    }
//}




//Console.Write("Please input an outside temperature value: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input < 0)
//{
//    Console.WriteLine("Salta");
//}
//else if (input <= 20)
//{
//    Console.WriteLine("Vesu");
//}
//else
//{
//    Console.WriteLine("Karsta");
//};



//Console.Write("What hour have you woke up today: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input > 0 && input < 12)
//{
//    Console.WriteLine("Geros dienos");
//}
//else if (input >= 12 && input < 18)
//{
//    Console.WriteLine("Geros popietes");
//}
//else
//{
//    Console.WriteLine("Gero vakaro");
//};



//Console.Write("Koks jusu amzius?: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input < 18)
//{
//    Console.WriteLine("Jums priklauso nepilnamecio akcija");
//}
//else if (input >= 18 && input < 65)
//{
//    Console.WriteLine("Jus esate suauges");
//}
//else
//{
//    Console.WriteLine("Jums priklauso senjoro akcija");
//}



//Console.Write("Iveskite metus: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input % 4 == 0 && (input % 100 != 0 || input % 400 == 0))
//{
//    Console.WriteLine("Tai yra keliamieji metai");
//}
//else
//{
//    Console.WriteLine("Tai nera keliamieji metai");
//}




//Console.Write("Iveskite skaiciu: ");
//int input = Convert.ToInt16(Console.ReadLine());

//if (input % 3 == 0 && input % 5 == 0)
//{
//    Console.WriteLine("FizzBuzz");
//}
//else if (input % 3 == 0)
//{
//    Console.WriteLine("Fizz");
//}
//else if (input % 5 == 0)
//{
//    Console.WriteLine("Buzz");
//}



//Console.WriteLine("Iveskite 2 skaicius: ");
//Console.Write("Pirmas: ");
//int input = Convert.ToInt16(Console.ReadLine());
//Console.Write("Antras: ");
//int input2 = Convert.ToInt16(Console.ReadLine());

//if (input > 0 && input2 > 0)
//{
//    Console.WriteLine("Abu skaiciai yra teigiami");
//}
//else if (input <= 0 && input2 <= 0)
//{
//    Console.WriteLine("Nei vienas skaicius nera teigiamas");
//}
//else if (input <= 0 || input2 <= 0)
//{
//    Console.WriteLine("Tik vianas skaicius yra teigiamas");
//}



//Console.WriteLine("Iveskite 3 skaicius: ");
//Console.Write("Pirmas: ");
//int input = Convert.ToInt16(Console.ReadLine());
//Console.Write("Antras: ");
//int input2 = Convert.ToInt16(Console.ReadLine());
//Console.Write("Trecias: ");
//int input3 = Convert.ToInt16(Console.ReadLine());

//if (input == input2 && input2 == input3)
//{
//    Console.WriteLine("Visi skaiciai lygus");
//}
//else if (input == input2 || input == input3 || input2 == input3)
//{
//    Console.WriteLine("Du skaiciai yra lygus");
//}
//else {
//    Console.WriteLine("Nei vienas skaicius nera lygus");
//}



//Console.WriteLine("Iveskite 3 skaicius: ");
//Console.Write("Pirmas: ");
//int input = Convert.ToInt16(Console.ReadLine());
//Console.Write("Antras: ");
//int input2 = Convert.ToInt16(Console.ReadLine());
//Console.Write("Trecias: ");
//int input3 = Convert.ToInt16(Console.ReadLine());

if (input > 0 && input2 > 0 && input3 > 0)
{
    Console.WriteLine(input + input2 + input3);
}
else if (input > 0 && input2 > 0)
{
    Console.WriteLine(input + input2);
}
else if (input > 0 && input3 > 0)
{
    Console.WriteLine(input + input3);
}
else if (input2 > 0 && input3 > 0)
{
    Console.WriteLine(input2 + input3);
}
else
{
    Console.WriteLine("neimanoma suskaiciuoti sumos");
}


