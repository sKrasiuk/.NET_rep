using System;

namespace MDB_Robot.Models;

public class Arm
{
    public string Material { get; set; }
    public int NumberOfJoints { get; set; }
    public int NumberOfFingers { get; set; }

    public Arm(string material, int numberOfJoints, int numberOfFingers)
    {
        Material = material;
        NumberOfJoints = numberOfJoints;
        NumberOfFingers = numberOfFingers;
    }
}
