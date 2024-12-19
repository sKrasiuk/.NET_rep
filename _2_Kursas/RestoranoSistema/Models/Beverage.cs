using System;

namespace RestoranoSistema.Models;

public class Beverage : Product
{
    public Beverage(int id, string name, decimal price) : base(id, name, price, "Beverage")
    {
    }
}
