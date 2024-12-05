namespace _15_oop_Interfaces.Models
{
    internal class GComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> CompareFunction;
        public GComparer(Func<T, T, int> compareFunction)
        {
            CompareFunction = compareFunction;
        }
        public int Compare(T x, T y)
        {
            return CompareFunction(x, y);
        }
    }
}
