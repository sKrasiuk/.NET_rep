using System.Linq.Expressions;
using MDB_Robot.Models;
using MDB_Robot.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var mongoDb = new MongoDbRepository();

        var robot1 = new Robot(
            arms: new List<Arm> { new Arm("Steel", 3, 5), new Arm("Steel", 3, 5) },
            legs: new List<Leg> { new Leg("Steel", 2, 50.5m), new Leg("Steel", 2, 50.5m) },
            torso: new Torso(100.0m, 80.0m),
            headType: HeadType.Triangle
        );

        var robot2 = new Robot(
            arms: new List<Arm> { new Arm("Titanium", 3, 5), new Arm("Titanium", 3, 5) },
            legs: new List<Leg> { new Leg("Titanium", 2, 40.5m), new Leg("Titanium", 2, 40.5m) },
            torso: new Torso(100.0m, 80.0m),
            headType: HeadType.Square
        );


        var robots = new List<Robot>
        {
            robot1,
            robot2
        };

        // Test 1: Add single robot
        Console.WriteLine("\nTest 1: Adding single robot");
        var addedRobot = mongoDb.AddRobot(robot1);
        Console.WriteLine($"Robot added successfully: {addedRobot != null}");
        Console.WriteLine($"Robot ID: {addedRobot?.Id}");

        // Test 2: Add multiple robots
        Console.WriteLine("\nTest 2: Adding multiple robots");
        var addedMultiple = mongoDb.AddRobots(robots);
        Console.WriteLine($"Multiple robots added: {addedMultiple}");

        // Test 3: Find robot by ID
        Console.WriteLine("\nTest 3: Finding robot by ID");
        var foundRobot = mongoDb.FindRobotById(addedRobot.Id);
        Console.WriteLine($"Robot found: {foundRobot != null}");

        // Test 4: Find robot by property
        Console.WriteLine("\nTest 4: Finding robot by property");
        var foundByProperty = mongoDb.FindRobotByProperty("HeadType", HeadType.Triangle);
        Console.WriteLine($"Robot found by property: {foundByProperty != null}");

        // Test 5: Update robot
        Console.WriteLine("\nTest 5: Updating robot");
        addedRobot.HeadType = HeadType.Round;
        var updated = mongoDb.UpdateRobot(addedRobot.Id, addedRobot);
        Console.WriteLine($"Robot updated: {updated}");

        // Test 6: Delete robot
        Console.WriteLine("\nTest 6: Deleting robot");
        var deleted = mongoDb.DeleteRobotById(addedRobot.Id);
        Console.WriteLine($"Robot deleted: {deleted}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}