using System;
using DB_Atsiskaitymas.Models;
using DB_Atsiskaitymas.Services;

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
        if (!_dbContext.Departments.Any(x => x.Name == name))
        {
            Console.WriteLine("\nNo such department exists.");
            return;
        }

        try
        {
            _dbContext.Departments.Remove(_dbContext.Departments.Single(x => x.Name == name));
            _dbContext.SaveChanges();
            Console.WriteLine($"\nDepartment {name} removed.");
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to delete the depatment: {name} - due to dependancies!");
        }
    }

    public List<Department> GetAllDepartments()
    {
        return _dbContext.Departments.ToList();
    }

    public Department? GetDepartmentById(int depId)
    {
        return _dbContext.Departments.FirstOrDefault(x => x.Id == depId);
    }
}
