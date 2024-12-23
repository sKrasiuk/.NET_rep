using System;

namespace Restoranas.Models;

public class Table
{
    public int Id { get; set; }
    public int Seats { get; set; }
    public bool IsOccupied { get; set; }
}
