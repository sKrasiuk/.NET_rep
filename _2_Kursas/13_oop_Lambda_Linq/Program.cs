using _13_oop_Lambda_Linq;


//var listOfInts = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//Func<int, int> IntsSq = x => x * x;
//var listOfIntsSq = listOfInts.Select(IntsSq).ToList();


//var listMixedInts = new List<int> { 1, -2, 3, 4, -5, 6, -7, 8, 9 };

//Func<int, bool> isPositive = x => x >= 0;
//var listPositiveInts = listMixedInts.Where(isPositive).ToList();


//var listMixedInts2 = new List<int> { 1, -2, 30, 4, -5, 6, -7, 8, 90 };
//var listPositiveInts2 = listMixedInts2.Where(x => x >= 0 && x < 11).ToList();

//var sortedListInts = listMixedInts2.OrderBy(x => x).ToList();
//var sortedListInts2 = listMixedInts2.OrderByDescending(x => x).ToList();


//var resGr = listMixedInts2.Max();



var people = new List<Person>
{
    new Person("Maryte", 21),
    new Person("Petriukas", 14),
    new Person("Onute", 71),
    new Person("Jonukas", 31),
    new Person("Izodorius", 41),
};

var names = people.Select(p => p.Name).ToList();
var ages = people.Select(p => p.Age).ToList();
//var agesSorted = ages.OrderBy(x => x).ToList();
var agesSorted = ages.Order().ToList();
var peopleStartingWithO = people.Where(p => p.Name.StartsWith("O")).ToList();
var peopleAgeMoreThan40 = people.Where(p => p.Age > 40).OrderBy(p => p.Age).ToList();


var peopleWithPets = new List<Person>
{
    new Person("Maryte", new List<Pet> {new Pet("Suo1")}),
    new Person("Petriukas",new List<Pet> {new Pet("Suo2")}),
    new Person("Onute", new List<Pet> {new Pet("Suo3")}),
    new Person("Jonukas", new List<Pet> {new Pet("Suo4")}),
    new Person("Izodorius", new List<Pet> {new Pet("Suo5")}),
};





Console.WriteLine();