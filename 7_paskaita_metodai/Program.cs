using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace _7_paskaita_metodai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PrintMenu();
            //GetUserSelection();
            //IsPasswordValid("123456789");
            //IsEmailValid("s.krasiukov@gmail.com");
            //Console.WriteLine(ConvertToEuros(10));
            //Console.WriteLine(GetInitials("Sergej", "Krasiukov"));
            //Console.WriteLine(CalculateCylinderVolume(1, 2));
            //IsNumberEven(2);
            //Console.WriteLine($"Rectangle area is: {CalculateRectangleArea(2, 3)}");
            Console.WriteLine(FactorialCalc(5));
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Spausdinti prekes");
            Console.WriteLine("2. Ziureti krepseli");
            Console.WriteLine("3. Isvalyti krepseli");
            Console.WriteLine("4. Pirkti");
            Console.WriteLine("5. Isjungti programa");
        }

        //private static int GetUserSelection()
        //{
        //    Console.WriteLine("Iveskite pasirinkuima: ");
        //    string input = Console.ReadLine();
        //    if (!string.IsNullOrEmpty(input))
        //    {
        //        if (int.TryParse(input, out int result) && (result >= 1 && result <= 5))
        //        {
        //            return result;
        //        }
        //        Console.WriteLine("Iveskite skaiciu tarp 1 ir 5.");
        //    }
        //    return -1;
        //}

        private static bool IsPasswordValid(string password)
        {
            if (password.Length > 8)
            {
                Console.WriteLine("password valid");
                return true;
            }
            Console.WriteLine("password invalid");
            return false;
        }

        private static bool IsEmailValid(string email)
        {
            char[] emailArray = email.ToCharArray();
            for (int i = 0; i < emailArray.Length; i++)
            {
                int index;
                if (emailArray[i] == '@')
                {
                    for (index = i; index < emailArray.Length; index++)
                    {
                        if (emailArray[index] == '.' && index != emailArray.Length - 1 && index != emailArray.Length - 2)
                        {
                            Console.WriteLine("email valid");
                            return true;
                        }
                    }
                }
            }
            //if (email.Contains('@'))
            //{
            //    if (email.Contains('.'))
            //    {
            //        Console.WriteLine("email valid");
            //        return true;
            //    }
            //}
            Console.WriteLine("email invalid");
            return false;
        }

        private static double ConvertToEuros(double dollars)
        {
            double rate = 0.85;
            return dollars * rate;
        }

        private static string GetInitials(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        private static double CalculateCylinderVolume(double radius, double height)
        {
            double volume = Math.PI * (Math.Pow(radius, 2)) * height;
            return volume;
        }

        private static bool IsNumberEven(int number)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("number is even");
                return true;
            }
            Console.WriteLine("number is not even");
            return false;
        }

        private static double CalculateRectangleArea(double length, double width)
        {
            return length * width;
        }

        private static int FactorialCalc(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }
            return number * FactorialCalc(number - 1);
        }
    }
}
