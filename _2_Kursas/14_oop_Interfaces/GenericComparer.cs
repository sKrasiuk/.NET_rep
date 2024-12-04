namespace _14_oop_Interfaces
{
    internal class GenericComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> CompareFunction;
        public GenericComparer(Func<T, T, int> compareFunction)
        {
            CompareFunction = compareFunction;
        }
        public int Compare(T x, T y)
        {
            return CompareFunction(x, y);
        }
    }
}
