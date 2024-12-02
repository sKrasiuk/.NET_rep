namespace _12_oop_delegates
{
    public class Delegates
    {
        public delegate string ReturnString(string firstName, string lastName, int age);
        public delegate int ReturnNumber(int num1, int num2);
        public delegate List<int> ReturnList(List<int> list, int step);
        public delegate string ReturnType<T>(T element);


        public delegate bool Filter(Person p);
    }
}
