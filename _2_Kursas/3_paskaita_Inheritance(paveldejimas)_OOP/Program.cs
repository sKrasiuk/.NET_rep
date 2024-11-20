using _3_paskaita_Inheritance_paveldejimas__OOP;
using _3_paskaita_Inheritance_paveldejimas__OOP.Models;

Car car = new(50);
Bike bike = new(30);

//car.PrintSpeed();
//bike.PrintSpeed();


Manager manager = new("M1", 20000);

//Employee employee1 = new("E1", 18000);
//Employee employee2 = new("E2", 15000);
//Employee employee3 = new("E3", 13000);

manager.Employees.Add(new("E1", 18000));
manager.Employees.Add(new("E2", 15000));
manager.Employees.Add(new("E3", 13000));

manager.programmers.Add(new("C#", "P1", 30000));
manager.programmers.Add(new("Java", "P2", 25000));
manager.programmers.Add(new("C++", "P3", 22000));


//manager.PrintProgrammers();
//manager.PrintEmployees();

var desra = new Food("Desra", 3.50);
desra.PrintInfo();
desra.PrintAllInfo();

var klaviatura = new Electronic("Klaviatura", 57.50);
klaviatura.PrintInfo();
klaviatura.PrintAllInfo();

var p1 = new Product("Test", 4.20);
p1.PrintAllInfo();