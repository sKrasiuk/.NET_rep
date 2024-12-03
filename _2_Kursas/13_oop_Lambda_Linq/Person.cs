namespace _13_oop_Lambda_Linq
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Person(string name, List<Pet> pets)
        {
            Name = name;
            Pets = pets;
        }
    }
}
