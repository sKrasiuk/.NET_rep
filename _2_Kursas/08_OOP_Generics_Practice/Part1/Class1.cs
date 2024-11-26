namespace _08_OOP_Generics_Practice.Part1
{
    internal class Class1<T1, T2>
    {
        public T1 Prop1 { get; set; }
        public T2 Prop2 { get; set; }

        public void PrintT1()
        {
            Console.WriteLine($"{Prop1}");
        }
        public void PrintT2()
        {
            Console.WriteLine($"{Prop2}");
        }
        public void SetProp1(T1 value)
        {
            Prop1 = value;
        }
        public void SetProp2(T2 value)
        {
            Prop2 = value;
        }
    }
}
