using _12_oop_delegates;
using static _12_oop_delegates.Delegates;
using static _12_oop_delegates.Methods;

var listOfInts = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//var returnString = new ReturnString(GetPersonData);
var returnNumber = new ReturnNumber(NumbersSum);
var returnList = new ReturnList(GenerateList);
returnList(listOfInts, 3);
var returnType = new ReturnType<int>(GetType<int>);
returnType(9);

//ReturnString returnString = delegate (string firstName, string lastName, int age)
//{
//    return $"Name: {firstName} | Surname: {lastName} | Age: {age}";
//};
//Console.WriteLine(returnString("Vardas", "Pavarde", 50));

var listOfPeople = new List<Person>
{
    new Person("Maryte", 21),
    new Person("Petriukas", 14),
    new Person("Onute", 69),
};

DisplayPeople("senior", listOfPeople, IsSenior);