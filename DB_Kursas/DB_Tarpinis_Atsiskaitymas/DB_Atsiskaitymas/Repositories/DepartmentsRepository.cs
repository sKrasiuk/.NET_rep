using System;
using System.Data.Common;
using DB_Atsiskaitymas.Models;
using DB_Atsiskaitymas.Services;
using Microsoft.EntityFrameworkCore;

namespace DB_Atsiskaitymas.Repositories;

public class DepartmentsRepository : IDisposable
{
    private readonly UniversityContext _dbContext;

    public DepartmentsRepository()
    {
        _dbContext = new UniversityContext();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public void AddDepartment(string name)
    {
        if (_dbContext.Departments.Any(x => x.Name == name))
        {
            Console.WriteLine("\nSuch department already exists.");
            return;
        }
        _dbContext.Departments.Add(new Department(name));
        _dbContext.SaveChanges();

        Console.WriteLine($"\nDepartment {name} added.");
    }


    public void RemoveDepartment(string name)
    {
        var department = _dbContext.Departments
            .Include(x => x.Lectures)
            .Include(x => x.Students)
            .FirstOrDefault(x => x.Name == name);
        if (department == null)
        {
            Console.WriteLine("\nNo such department exists.");
            return;
        }

        if (department.Lectures.Any() || department.Students.Any())
        {
            Console.WriteLine($"Cannot delete depatment {name} - it has existing lectures or students!");
            return;
        }

        try
        {
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();
            Console.WriteLine($"\nDepartment {name} removed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public List<Department> GetAllDepartments()
    {
        return _dbContext.Departments.ToList();
    }
}
