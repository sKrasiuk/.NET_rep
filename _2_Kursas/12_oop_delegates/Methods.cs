using static _12_oop_delegates.Delegates;

namespace _12_oop_delegates
{
    public static class Methods
    {
        public static string GetPersonData(string name, string surname, int age)
        {
            return $"First name: {name} | Surname: {surname} | Age: {age}";
        }

        public static int NumbersSum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static List<int> GenerateList(List<int> list, int step)
        {
            var newList = new List<int>();

            for (int i = 0; i < list.Count; i += step)
            {
                newList.Add(list[i]);
            }
            return newList;
        }

        public static string GetType<T>(T element)
        {
            return element.GetType().ToString();
        }

        public static bool IsChild(Person p)
        {
            if (p.Age < 18)
            {
                return true;
            }
            return false;
        }
        public static bool IsAdult(Person p)
        {
            if (p.Age >= 18)
            {
                return true;
            }
            return false;
        }
        public static bool IsSenior(Person p)
        {
            if (p.Age >= 65)
            {
                return true;
            }
            return false;
        }
        public static string DisplayPeople(string title, List<Person> people, Filter filter)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    return $"{title} | Name: {person.Name} | Age: {person.Age}";
                }
            }
            return null;
        }
    }
}
