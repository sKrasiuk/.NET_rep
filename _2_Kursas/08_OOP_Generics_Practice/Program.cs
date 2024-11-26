using _08_OOP_Generics_Practice.Part1;
using _08_OOP_Generics_Practice.Part2;

//var class1 = new Class1<int, string>();

//class1.SetProp1(9);
//class1.SetProp2("Hello");

//class1.PrintT1();
//class1.PrintT2();

var square = new FourSideGeometricFigure("Square", 5, 5);
var rectangle = new FourSideGeometricFigure("Rectangle", 3, 5);

//Console.WriteLine(square);
//Console.WriteLine(rectangle);

//Generator<FourSideGeometricFigure>.Show(square);
//Generator<FourSideGeometricFigure>.Show(rectangle);

//Type<string, int>.GetType("square", 96);

var list = new List<int> { 1, 2, 3, 4, 5 };
var readOnlyList = new ReadOnlyList<int>(list);

//readOnlyList.PrintListItems();
readOnlyList.ListToArray();

readOnlyList.FindOneValueOrException(3);
readOnlyList.FindOneValueOrDefault(7);
readOnlyList.IsContainsValue(7);