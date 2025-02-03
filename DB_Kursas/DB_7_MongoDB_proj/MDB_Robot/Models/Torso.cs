using System;

namespace MDB_Robot.Models;

public class Torso
{
    public decimal ChestMeasurements { get; set; }
    public decimal WaistMeasurements { get; set; }

    public Torso(decimal chestMeasurements, decimal waistMeasurements)
    {
        ChestMeasurements = chestMeasurements;
        WaistMeasurements = waistMeasurements;
    }
}
