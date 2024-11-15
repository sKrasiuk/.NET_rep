using _2_paskaita_OOP_class_methods;

var numbers = new Numbers();

//numbers.AddValue(1);
//numbers.AddValue(2);
//numbers.AddValue(3);
//numbers.AddValue(4);
//numbers.AddValue(5);

//numbers.PrintListComponents();

var rectangle = new Rectangle(5, 2);

double rArea = rectangle.CalculateArea();
double rPerimeter = rectangle.CalculatePerimeter();

//Console.WriteLine(area);
//Console.WriteLine(perimeter);

var circle = new Circle(5);


var cArea = circle.CalculateArea();
var cPerimeter = circle.CalculatePerimeter();

Library library = new();

library.AddBook("Book_1", "Author_1", 1990);
library.AddBook("Book_2", "Author_1", 2000);
library.AddBook("Book_3", "Author_3", 2024);






Console.ReadLine();