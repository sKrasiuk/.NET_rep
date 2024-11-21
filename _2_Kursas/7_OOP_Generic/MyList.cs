namespace _7_OOP_Generic
{
    internal class MyList<T>
    {
        private T[] MyArray { get; set; }
        private int Index = 0;
        private int Size = 10;

        public MyList()
        {
            MyArray = new T[Size];
        }

        public void AddElement(T elementToAdd)
        {
            if (CheckIfFull())
            {
                MyArray[Index] = elementToAdd;
                Index++;
            }
            else
            {
                throw new ArgumentNullException(nameof(elementToAdd));
            }
        }

        public void RemoveElement(T elementToRemove)
        {
            for (int i = 0; i < MyArray.Count(); i++)
            {
                if (MyArray[i].Equals(elementToRemove))
                {
                    MyArray.;
                }

            }
        }

        private bool CheckIfFull()
        {
            if (Index == Size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private T[] IncreaseListSize()
        {
            Size += (Size / 2);
            var newArray = new T[Size];
            MyArray.CopyTo(newArray, 0);
            return newArray;
        }
    }
}
