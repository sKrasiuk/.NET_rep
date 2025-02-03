using System;
using DB_Atsiskaitymas.Services;
using DB_Atsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_Atsiskaitymas.Repositories;

public class StudentsRepository : IDisposable
{
    private readonly UniversityContext _dbContext;

    public StudentsRepository()
    {
        _dbContext = new UniversityContext();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public void AddStudent(string name, string surname)
    {
        if (_dbContext.Students.Any(x => x.Name == name && x.Surname == surname))
        {
            Console.WriteLine("Such student already exists.");
            return;
        }
        _dbContext.Students.Add(new Student
        {
            Name = name,
            Surname = surname
        });
        _dbContext.SaveChanges();

        Console.WriteLine($"\nStudent {name} {surname} added.");
    }

    public void RemoveStudent(string name, string surname)
    {
        if (!_dbContext.Students.Any(x => x.Name == name && x.Surname == surname))
        {
            Console.WriteLine("\nNo such student exists.");
            return;
        }
        _dbContext.Students.Remove(_dbContext.Students.Single(x => x.Name == name && x.Surname == surname));
        _dbContext.SaveChanges();

        Console.WriteLine($"\nStudent {name} {surname} removed.");
    }

    public void SetDepartment(string studentName, string studentSurname, string departmentName, bool assignLectures = true)
    {
        var student = _dbContext.Students
            .Include(x => x.Lectures)
            .FirstOrDefault(x => x.Name == studentName && x.Surname == studentSurname);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        var department = _dbContext.Departments
            .Include(x => x.Lectures)
            .FirstOrDefault(x => x.Name == departmentName);
        if (department == null)
        {
            Console.WriteLine("Department not found.");
            return;
        }

        if (student.DepartmentId == department.Id)
        {
            Console.WriteLine($"Student {student.Name} {student.Surname} is already assigned to department: {student.Department?.Name}");
            return;
        }

        student.DepartmentId = department.Id;
        student.Department = department;

        if (assignLectures)
        {
            student.Lectures.Clear();
            foreach (var lecture in department.Lectures)
            {
                student.Lectures.Add(lecture);
            }
        }

        try
        {
            _dbContext.SaveChanges();
            Console.WriteLine($"Student assigned to department: {department.Name}");
            if (assignLectures)
            {
                Console.WriteLine($"Assigned {department.Lectures.Count} department lectures");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void AssignDepLectures(string studentName, string studentSurname)
    {
        var student = _dbContext.Students
            .Include(x => x.Department)
            .Include(x => x.Lectures)
            .FirstOrDefault(x => x.Name == studentName && x.Surname == studentSurname);

        if (student == null || student.Department == null)
        {
            Console.WriteLine("\nStudent not found or not assigned to any department.");
            return;
        }

        var departmentLectures = _dbContext.Departments
            .Include(x => x.Lectures)
            .First(x => x.Id == student.Department.Id)
            .Lectures;

        student.Lectures.Clear();
        foreach (var lecture in departmentLectures)
        {
            if (!student.Lectures.Any(x => x.Id == lecture.Id))
            {
                student.Lectures.Add(lecture);
            }
        }

        try
        {
            _dbContext.SaveChanges();
            Console.WriteLine($"\nAssigned {departmentLectures.Count} department lectures to student {studentName} {studentSurname}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError assigning lectures: {ex.Message}.");
        }
    }

    public List<Student> GetAllSudents()
    {
        return _dbContext.Students.ToList();
    }

    public List<Student> GetStudentsByDepartment(int departmentId)
    {
        var department = _dbContext.Departments
            .Include(x => x.Students)
            .FirstOrDefault(x => x.Id == departmentId);
        
        if (department == null)
        {
            Console.WriteLine("Department not found.");
            return new List<Student>();
        }

        return department.Students.ToList();
    }
}
