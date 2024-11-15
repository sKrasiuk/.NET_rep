namespace _3_paskaita_Inheritance_paveldejimas__OOP
{
    public class Programmer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Programmer(string programmingLanguage,string name, double salary) : base(name, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

    }
}
