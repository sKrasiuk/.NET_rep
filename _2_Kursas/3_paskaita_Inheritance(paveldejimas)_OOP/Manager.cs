namespace _3_paskaita_Inheritance_paveldejimas__OOP
{
    public class Manager : Employee
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Programmer> programmers { get; set; } = [];

        public Manager(string name, double salary) : base(name, salary)
        {
            //Salary = salary;
            //Name = name;
        }

        public void PrintEmployees()
        {
            Console.WriteLine("Manager:\n");
            Console.WriteLine($"{Name} | Salary: {Salary}");
            Console.WriteLine("\n\nDependant employes:\n");
            foreach (var employee in Employees)
            {
                Console.WriteLine($"{employee.Name} | Salary: {employee.Salary}");
            }
        }

        public void PrintProgrammers()
        {
            Console.WriteLine("Programmers:\n");
            foreach (var programmer in programmers)
            {
                Console.WriteLine($"{programmer.Name} | Salary: {programmer.Salary} | Programming language: {programmer.ProgrammingLanguage}");
            }
        }
    }
}
