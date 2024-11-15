namespace _3_paskaita_Inheritance_paveldejimas__OOP
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public Employee()
        {
            
        }
    }
}
