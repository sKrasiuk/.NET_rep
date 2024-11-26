namespace _08_OOP_Generics_Practice.Part1
{
    public static class Type<T1, T2>
    {
        public static void GetType(T1 input1, T2 input2)
        {
            Console.WriteLine(input1?.GetType());
            Console.WriteLine(input2?.GetType());
        }
    }
}
