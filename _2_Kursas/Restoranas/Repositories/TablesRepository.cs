using System;
using System.Collections;
using Restoranas.Models;

namespace Restoranas.Repositories;

public class TablesRepository : IEnumerable<Table>
{
    public TablesRepository()
    {
        GetTables();
    }

    private readonly string filePath = "Tables.txt";

    private List<Table> GetTables()
    {
        var tables = new List<Table>();

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
                var table = new Table
                {
                    Id = int.Parse(parts[0]),
                    Seats = int.Parse(parts[1]),
                    IsOccupied = false
                };
                tables.Add(table);
            }
        }
        return tables;
    }

    public IEnumerator<Table> GetEnumerator()
    {
        return GetTables().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
