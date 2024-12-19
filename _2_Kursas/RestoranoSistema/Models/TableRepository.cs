using System;

namespace RestoranoSistema.Models;

public class TableRepository
{
    private List<Table> tables = new List<Table>();

    public TableRepository()
    {
        string[] lines = File.ReadAllLines("tables.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            int number = int.Parse(parts[0]);
            int seats = int.Parse(parts[1]);
            tables.Add(new Table(number, seats));
        }
    }

    public List<Table> GetTables()
    {
        return tables;
    }
}
