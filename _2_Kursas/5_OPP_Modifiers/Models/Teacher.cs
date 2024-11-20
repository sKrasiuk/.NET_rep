namespace _5_OPP_Modifiers.Models
{
    public class Teacher : Person
    {
        public Teacher(string name, int age, string subject) : base(name, age)
        {
            Subject = subject;
        }

        private string Subject { get; set; }

        public string GetSubject()
        {
            PrintInfo();
            Console.WriteLine($"Subject: {Subject}");
            return Subject;
        }
    }
}
