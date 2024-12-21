using System;

namespace RestoranoSistema.Models;

public class Food : Product
{
    public Food(string name, decimal price) : base(name, price, "Food")
    {
    }
}

