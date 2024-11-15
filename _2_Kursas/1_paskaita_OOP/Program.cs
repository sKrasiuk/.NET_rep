using _1_paskaita_OOP;

Person sergej = new Person("Sergej", 40, 175);
//Console.WriteLine($"{sergej.Name}: age {sergej.Age}; tall: {sergej.Tall} ");

School school = new("Vilnius", "Ateities", 500);
//Console.WriteLine("City: {0}, Name: {1}, Number of stutents: {2}", school.City, school.Name, school.StudentsCount);

Book abecele = new("Abecele","Liaudis", 1650, "Global");
//Console.WriteLine("Book name: {0}, Author: {1}, Year: {2}, Country of issue: {3}", abecele.Name,abecele.Author,abecele.Year, abecele.CountryOfIssue);

List<Book> books = new()
{
     abecele
};

List<Book> byAuthor = Methods.GetBooksByAuthor(books, "Liaudis");
Console.ReadLine();
