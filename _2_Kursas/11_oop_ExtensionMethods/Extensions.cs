namespace _11_oop_ExtensionMethods
{
    public static class Extensions
    {
        public static bool IsPositive(this int num)
        {
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsEven(this int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsLess(this int num, int num2)
        {
            if (num2 > num)
            {
                return true;
            }
            return false;
        }

        public static bool IsContainsSpace(this string str)
        {
            if (str.Contains(' '))
            {
                return true;
            }
            return false;
        }

        public static string GenerateEmailAddress(this string name, string surname, int yearOfBirth, string domain)
        {
            return $"{name}{surname}{yearOfBirth}@{domain}.com".ToLower();
        }

        public static bool FindAndReturnIfEqual<T>(this List<T> list, T value, out T foundValue)
        {
            foundValue = default;
            foreach (var item in list)
            {
                if (item.Equals(value))
                {
                    foundValue = value;
                    return true;
                }
            }
            return false;
        }

        public static List<T> EveryOtherWord<T>(this List<T> list)
        {
            var newList = new List<T>(list.Count / 2);
            for (int i = 0; i < list.Count; i += 2)
            {
                newList.Add(list[i]);
            }
            return newList;
        }
    }
}
