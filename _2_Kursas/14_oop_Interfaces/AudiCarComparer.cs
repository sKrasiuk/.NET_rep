namespace _14_oop_Interfaces
{
    internal class AudiCarComparer : IComparer<AudiCar>
    {
        public int Compare(AudiCar x, AudiCar y)
        {
            return string.Compare(x.Model, y.Model);
        }
    }
}
