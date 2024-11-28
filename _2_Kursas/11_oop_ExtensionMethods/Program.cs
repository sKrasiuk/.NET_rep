using _11_oop_ExtensionMethods;

int x = 2;
string str = "string string";
var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

x.IsPositive();
x.IsEven();
x.IsLess(3);
str.IsContainsSpace();
Extensions.GenerateEmailAddress("Vardenis", "Pavardenis", 1990, "gmail");

list.EveryOtherWord();
list.FindAndReturnIfEqual(9, out int value);
Console.WriteLine(value);