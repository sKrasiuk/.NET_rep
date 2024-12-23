using System;
using System.Collections;
using Restoranas.Models;

namespace Restoranas.Repositories;

public class WaitersRepository : IEnumerable<Waiter>
{
    public WaitersRepository()
    {
        GetWaiters();
    }

    private readonly string filePath = "waiters.txt";

    private List<Waiter> GetWaiters()
    {
        var waiters = new List<Waiter>();

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file {filePath} does not exist.");
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                var waiter = new Waiter
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1]
                };
                waiters.Add(waiter);
            }
        }

        return waiters;
    }

    public IEnumerator<Waiter> GetEnumerator()
    {
        return GetWaiters().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
