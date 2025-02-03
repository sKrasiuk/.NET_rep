using System;
using DB_Atsiskaitymas.Models;
using DB_Atsiskaitymas.Services;

namespace DB_Atsiskaitymas.Repositories;

public class LecturesRepository : IDisposable
{
    private readonly UniversityContext _dbContext;

    public LecturesRepository()
    {
        _dbContext = new UniversityContext();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public void AddLecture(string name)
    {
        if (_dbContext.Lectures.Any(x => x.Name == name))
        {
            Console.WriteLine("\nSuch lecture already exists.");
            return;
        }
        _dbContext.Lectures.Add(new Lecture(name));
        _dbContext.SaveChanges();

        Console.WriteLine($"\nLecture {name} added.");
    }

    public void RemoveLecture(string name)
    {
        if (!_dbContext.Lectures.Any(x => x.Name == name))
        {
            Console.WriteLine("\nNo such lecture exists.");
            return;
        }
        _dbContext.Lectures.Remove(_dbContext.Lectures.Single(x => x.Name == name));
        _dbContext.SaveChanges();

        Console.WriteLine($"\nLecture {name} removed.");
    }

    public void SetDepartment(string lectureName, string departmentName)
    {
        var lecture = _dbContext.Lectures.FirstOrDefault(x => x.Name == lectureName);
        if (lecture == null)
        {
            Console.WriteLine("\nSuch lecture not found.");
            return;
        }

        var department = _dbContext.Departments.FirstOrDefault(x => x.Name == departmentName);
        if (department == null)
        {
            Console.WriteLine("\nSuch department not found.");
            return;
        }

        if (lecture.Departments.Any(x => x.Id == department.Id))
        {
            Console.WriteLine($"\nLecture {lectureName} is already assigned to department: {departmentName}");
            return;
        }

        lecture.Departments.Add(department);

        try
        {
            _dbContext.SaveChanges();
            Console.WriteLine($"\nLecture {lectureName} assigned to department: {departmentName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError assigning lecture to department: {ex.Message}");
        }
    }

    public List<Lecture> GetAllLectures()
    {
        return _dbContext.Lectures.ToList();
    }
}
