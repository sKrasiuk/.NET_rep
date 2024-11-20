using _4_Abstract_oop;

var square = new Square(2);
var triangle = new Triangle(2, 4, 6, 5);

//Console.WriteLine("Square area: {0}, Square perimeter: {1}",square.GetArea(),square.GetPerimeter());
//Console.WriteLine("Triangle area: {0}, Triangle perimeter: {1}",triangle.GetArea(),triangle.GetPerimeter());

//var dog = new Dog();
//var cat = new Cat();

//dog.MakeNoise();
//cat.MakeNoise();

var shapes = new List<GeometricShape>
{
    square,
    triangle
};

foreach (var shape in shapes)
{
    Console.WriteLine(shape.GetArea());
    Console.WriteLine(shape.GetPerimeter());
}


