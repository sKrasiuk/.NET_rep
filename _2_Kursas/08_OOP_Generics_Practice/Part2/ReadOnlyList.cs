using System.Diagnostics.Tracing;

namespace _08_OOP_Generics_Practice.Part2
{
    public class ReadOnlyList<T>
    {
        private List<T> List { get; }

        public ReadOnlyList(List<T> list)
        {
            List = list;
        }

        public void PrintListItems()
        {
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }

        public T[] ListToArray()
        {
            var newArray = new T[List.Count];
            for (int i = 0; i < List.Count; i++)
            {
                newArray[i] = List[i];
            }
            return newArray;
        }

        public T FindOneValueOrException(T value)
        {
            int counter = 0;
            T foundValue = default;

            foreach (var item in List)
            {
                if (item.Equals(value))
                {
                    counter++;
                    if (counter > 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "More than one instance obtained!");
                    }
                    if (counter < 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "None instances obtained!");
                    }
                    foundValue = item;
                }
            }
            return foundValue;
        }

        public T FindOneValueOrDefault(T value)
        {
            int counter = 0;
            T foundValue = default;

            foreach (var item in List)
            {
                if (item.Equals(value))
                {
                    counter++;
                    if (counter > 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "More than one instance obtained!");
                    }
                    foundValue = item;
                }
            }
            return foundValue;
        }

        public bool IsContainsValue(T value)
        {
            foreach (var item in List)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
