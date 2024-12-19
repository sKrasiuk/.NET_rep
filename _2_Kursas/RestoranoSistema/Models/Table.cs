using System;

namespace RestoranoSistema.Models;

public class Table
{
    public int Number { get; set; }
    public int Seats { get; set; }
    public bool IsOccupied { get; set; }
    // public Order Order { get; set; }

    public Table(int number, int seats)
    {
        Number = number;
        Seats = seats;
        IsOccupied = false;
        // Order = null;
    }

    public void Occupy(Order order)
    {
        IsOccupied = true;
        // Order = order;
    }

    public void Vacate()
    {
        IsOccupied = false;
        // Order = null;
    }
}