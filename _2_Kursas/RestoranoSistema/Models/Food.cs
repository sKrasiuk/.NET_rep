using System;

namespace RestoranoSistema.Models;

public class Food : Product
{
    public Food(int id, string name, decimal price) : base(id, name, price, "Food")
    {
    }
}
