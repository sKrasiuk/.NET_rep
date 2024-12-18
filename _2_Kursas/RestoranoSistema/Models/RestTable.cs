using System;

namespace RestoranoSistema.Models;

public class RestTable
{
    public int TableNumber { get; set; }
    public bool IsOccupied { get; set; } = false;
    public int NumberOfSeats { get; set; }
}
