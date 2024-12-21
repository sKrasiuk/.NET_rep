using System;

namespace RestoranoSistema.Models;

public class Beverage : Product
{
    public Beverage(string name, decimal price) : base(name, price, "Beverage")
    {
    }
}
