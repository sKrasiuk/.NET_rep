using System;
using DB_Atsiskaitymas.Repositories;

namespace DB_Atsiskaitymas.Managers;

public class AppManager
{
    private readonly DepartmentsRepository _departmentsRepo;
    private readonly StudentsRepository _studentsRepo;
    private readonly LecturesRepository _lecturesRepo;

    public AppManager()
    {
        _departmentsRepo = new DepartmentsRepository();
        _studentsRepo = new StudentsRepository();
        _lecturesRepo = new LecturesRepository();
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== University Management System ===\n");
            Console.WriteLine("1: Create Department");
            Console.WriteLine("2: Create / Update Lecture (requires Department)");
            Console.WriteLine("3: Create / Update Student (requires Department)");
            Console.WriteLine("4: Refresh Database (reqiured after new Lecture addition)");
            Console.WriteLine("5: Delete Student");
            Console.WriteLine("6: Delete Lecture");
            Console.WriteLine("7: Delete Department");
            Console.WriteLine("8: View Department Details");
            Console.WriteLine("0: Exit");
            Console.Write("\nSelect an option: ");

            string choice = PromptInput();
            switch (choice)
            {
                case "1":
                    CreateDepartment();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("1: Create Lecture (requires Department)");
                    Console.WriteLine("2: Update Lecture");
                    Console.Write("\nSelect a lecture number\t(0 to cancel): ");

                    choice = PromptInput();
                    switch (choice)
                    {
                        case "1":
                            CreateLecture();
                            break;
                        case "2":
                            // ChangeLectureDepartment();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("\nInvalid option selected.");
                            break;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("1: Create Student (requires Department)");
                    Console.WriteLine("2: Update Student");
                    Console.Write("\nSelect a student number\t(0 to cancel): ");

                    choice = PromptInput();
                    switch (choice)
                    {
                        case "1":
                            CreateStudent();
                            break;
                        case "2":
                            ChangeStudentDepartment();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("\nInvalid option selected.");
                            break;
                    }
                    break;
                case "4":
                    UpdateRelations(); // Update data / refresh dependancies
                    break;
                case "5":
                    DeleteStudent();
                    break;
                case "6":
                    DeleteLecture();
                    break;

                case "7":
                    DeleteDepartment();
                    break;
                case "8":
                    // ViewDepartmentDetails();
                    break;
                case "9":
                    // View Student details;
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid option selected.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        _departmentsRepo.Dispose();
        _studentsRepo.Dispose();
        _lecturesRepo.Dispose();
    }

    private string PromptInput()
    {
        while (true)
        {
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }

            Console.Write("Invalid input. Please try again: ");
        }
    }

    private void CreateDepartment()
    {
        Console.Clear();

        Console.Write("Enter Department Name: ");
        string depName = PromptInput();
        _departmentsRepo.AddDepartment(depName);
    }

    private void CreateStudent()
    {
        Console.Clear();

        Console.Write("Enter Student Name: ");
        string name = PromptInput();
        Console.Write("Enter Student Surname: ");
        string surname = PromptInput();

        _studentsRepo.AddStudent(name, surname);

        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("\nNo departments exist yet. Create one before assigning.");
            return;
        }

        Console.WriteLine("\nAvailable Departments:");
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect a department number: ");
        if (int.TryParse(PromptInput(), out int depIndex) &&
            depIndex >= 1 && depIndex <= departments.Count)
        {
            string depName = departments[depIndex - 1].Name;
            _studentsRepo.SetDepartment(name, surname, depName, assignLectures: true);
        }
        else
        {
            Console.WriteLine("Invalid department selection.");
        }
    }

    private void ChangeStudentDepartment()
    {
        Console.Clear();

        Console.WriteLine("=== Move Student to Another Department ===\n");
        var students = _studentsRepo.GetAllSudents();
        if (students.Count == 0)
        {
            Console.WriteLine("No students found. Please create a student first.");
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            string departmentName = _departmentsRepo.GetDepartmentById((int)students[i].DepartmentId)?.Name ?? "Unknown Department";
            Console.WriteLine($"{i + 1}: {students[i].Name} {students[i].Surname} - department: {departmentName}");
        }
        Console.Write("\nSelect a student number\t(0 to cancel): ");

        if (!int.TryParse(PromptInput(), out int studIndex) || studIndex < 0 || studIndex > students.Count)
        {
            Console.WriteLine("Invalid input. Returning to previous menu.");
            return;
        }
        if (studIndex == 0)
        {
            return;
        }

        string sName = students[studIndex - 1].Name;
        string sSurname = students[studIndex - 1].Surname;

        // Console.Clear();

        var departments = _departmentsRepo.GetAllDepartments();
        if (departments.Count == 0)
        {
            Console.WriteLine("No departments available. Create one first.");
            return;
        }

        Console.WriteLine("Available Departments:\n");
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect a department number (0 to cancel): ");
        if (!int.TryParse(PromptInput(), out int depIndex) || depIndex < 0 || depIndex > departments.Count)
        {
            Console.WriteLine("Invalid department selection. Returning to previous menu.");
            return;
        }
        if (depIndex == 0)
        {
            return;
        }

        string depName = departments[depIndex - 1].Name;
        _studentsRepo.SetDepartment(sName, sSurname, depName, assignLectures: true);

        Console.WriteLine($"\nStudent: {sName} {sSurname} - successfully moved to department: {depName}.");
    }

    private void CreateLecture()
    {
        Console.Clear();

        Console.Write("Enter Lecture Name: ");
        string lectureName = PromptInput();

        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("\nNo departments exist yet. Create one before assigning.");
            return;
        }

        Console.WriteLine("\nAvailable Departments:");
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect a department number: ");
        if (int.TryParse(PromptInput(), out int depIndex) &&
            depIndex >= 1 && depIndex <= departments.Count)
        {
            string depName = departments[depIndex - 1].Name;
            _lecturesRepo.AddLecture(lectureName);
            _lecturesRepo.SetDepartment(lectureName, depName);
        }
        else
        {
            Console.WriteLine("Invalid department selection.");
        }

        Console.Write("Enter another department number, or '0' to finish: ");
        while (true)
        {
            string userChoice = PromptInput();

            if (userChoice == "0")
            {
                Console.WriteLine("\nFinished assigning departments to the lecture.");
                break;
            }

            if (int.TryParse(userChoice, out depIndex))
            {
                if (depIndex >= 1 && depIndex <= departments.Count)
                {
                    string depName = departments[depIndex - 1].Name;
                    _lecturesRepo.SetDepartment(lectureName, depName);
                    Console.Write("Enter another department number, or '0' to finish: ");
                }
            }
            else
            {
                Console.Write("\nInvalid input. Please enter a department number or '0': ");
            }
        }
    }

    private void DeleteStudent()
    {
        Console.Clear();

        Console.WriteLine("Existing Students:\t(0: Back)\n");
        var students = _studentsRepo.GetAllSudents();
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {students[i].Name} {students[i].Surname}");
        }

        Console.Write("\nSelect a student number: ");
        if (int.TryParse(PromptInput(), out int studIndex) &&
            studIndex >= 1 && studIndex <= students.Count)
        {
            string sName = students[studIndex - 1].Name;
            string sSurname = students[studIndex - 1].Surname;
            _studentsRepo.RemoveStudent(sName, sSurname);
        }
        else if (studIndex == 0)
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid student selection.");
        }
    }

    private void DeleteLecture()
    {
        Console.Clear();

        Console.WriteLine("Existing Lectures:\t(0: Back)\n");
        var lectures = _lecturesRepo.GetAllLectures();
        for (int i = 0; i < lectures.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {lectures[i].Name}");
        }

        Console.Write("\nSelect a lecture number: ");
        if (int.TryParse(PromptInput(), out int lecIndex) &&
            lecIndex >= 1 && lecIndex <= lectures.Count)
        {
            string lecName = lectures[lecIndex - 1].Name;
            _lecturesRepo.RemoveLecture(lecName);
        }
        else if (lecIndex == 0)
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid lecture selection.");
        }
    }

    private void DeleteDepartment()
    {
        Console.Clear();

        Console.WriteLine("Existing Departments:\t(0: Back)\n");
        var departments = _departmentsRepo.GetAllDepartments();
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect a department number: ");
        if (int.TryParse(PromptInput(), out int depIndex) &&
            depIndex >= 1 && depIndex <= departments.Count)
        {
            string depName = departments[depIndex - 1].Name;
            _departmentsRepo.RemoveDepartment(depName);
        }
        else if (depIndex == 0)
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid department selection.");
        }
    }

    private void UpdateRelations()
    {
        var students = _studentsRepo.GetAllSudents();
        foreach (var student in students)
        {
            _studentsRepo.AssignDepLectures(student.Name, student.Surname);
        }
    }
}