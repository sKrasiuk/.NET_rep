using System;

namespace MDB_Robot.Models;

public class Leg
{
    public string Material { get; set; }
    public int NumberOfJoints { get; set; }
    public decimal SizeOfFoot { get; set; }

    public Leg(string material, int numberOfJoints, decimal sizeOfFoot)
    {
        Material = material;
        NumberOfJoints = numberOfJoints;
        SizeOfFoot = sizeOfFoot;
    }
}
