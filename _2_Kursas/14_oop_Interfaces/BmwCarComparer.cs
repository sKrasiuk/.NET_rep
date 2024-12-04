namespace _14_oop_Interfaces
{
    internal class BmwCarComparer : IComparer<BmwCar>
    {
        public int Compare(BmwCar x, BmwCar y)
        {
            return string.Compare(x.Model, y.Model);
        }
    }
}
