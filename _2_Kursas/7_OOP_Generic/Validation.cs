namespace _7_OOP_Generic
{
    public static class Validation<T, F>
    {
        public static void Validate(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                Console.WriteLine(value);
            }
        }

        public static void PrintTypesAndValues(T value, F value2)
        {
            Console.WriteLine("{0}: {1} | {2}: {3}", value.GetType().Name, value, value2.GetType().Name, value2);
        }
    }
}
