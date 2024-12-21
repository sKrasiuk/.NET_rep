using System;

namespace RestoranoSistema.Models;

public class WaiterRepository
{
    private List<Waiter> waiters = new List<Waiter>();

    public WaiterRepository()
    {
        string[] lines = File.ReadAllLines("waiters.txt");
        foreach (var line in lines)
        {
            string[] parts = line.Split(',');
            int id = int.Parse(parts[0]);
            string name = parts[1];
            waiters.Add(new Waiter(name));
        }
    }

    public Waiter GetWaiter(string name)
    {
        return waiters.FirstOrDefault(w => w.Name == name);
    }
    public List<Waiter> GetWaiters()
    {
        return waiters;
    }
}

