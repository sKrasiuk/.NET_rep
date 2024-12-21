using System;

namespace RestoranoSistema.Models;

public class Table
{
    public int Id { get; init; }
    public int Seats { get; init; }
    public bool IsOccupied { get; set; }
    public List<Order> Orders { get; set; }

    public Table(int id, int seats)
    {
        Id = id;
        Seats = seats;
        IsOccupied = false;
        Orders = new List<Order>();
    }
    public void Occupy()
    {
        IsOccupied = true;
    }

    public void Free()
    {
        IsOccupied = false;
    }

}

