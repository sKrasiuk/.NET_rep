namespace _5_OPP_Modifiers.Models
{
    public class Student : Person
    {
        private int Id { get; set; }
        public Student(string name, int age, int id) : base(name, age)
        {
            Id = id;
        }

        public int GetStudentId()
        {
            PrintInfo();
            Console.WriteLine($"ID: {Id}");
            return Id;
        }
    }
}
