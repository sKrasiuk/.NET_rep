namespace _08_OOP_Generics_Practice.Part1
{
    public static class Generator<T>
    {
        public static void Show(T value)
        {
            Console.WriteLine(value);
        }
    }
}
