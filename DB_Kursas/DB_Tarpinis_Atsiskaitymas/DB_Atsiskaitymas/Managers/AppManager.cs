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
            Console.WriteLine("5: Access Records");
            Console.WriteLine("6: Delete entities");
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
                    Console.Write("\nSelect a lecture number (0: Cancel): ");

                    choice = PromptInput();
                    switch (choice)
                    {
                        case "1":
                            CreateLecture();
                            break;
                        case "2":
                            // ManageLectureDepartments();
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
                    Console.Write("\nSelect a student number (0: Cancel): ");

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
                    Console.Clear();
                    Console.WriteLine("1: Print Students by Department");
                    Console.WriteLine("2: Print Lectures by Department");
                    Console.WriteLine("3: Print Lectures by Student");
                    Console.Write("\nSelect an option number (0: Cancel): ");

                    choice = PromptInput();
                    switch (choice)
                    {
                        case "1":
                            PrintStudentsByDepartment();
                            break;
                        case "2":
                            PrintLecturesByDepartment();
                            break;
                        case "3":
                            PrintLecturesByStudent();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("\nInvalid option selected.");
                            break;
                    }
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("1: Delete Student");
                    Console.WriteLine("2: Delete Lecture");
                    Console.WriteLine("3: Delete Department");
                    Console.Write("\nSelect an option number (0: Cancel): ");

                    choice = PromptInput();
                    switch (choice)
                    {
                        case "1":
                            DeleteStudent();
                            break;
                        case "2":
                            DeleteLecture();
                            break;
                        case "3":
                            DeleteDepartment();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("\nInvalid option selected.");
                            break;
                    }
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

        Console.Write("Enter Department Name (0: Cancel): ");
        string depName = PromptInput();
        if (depName == "0")
        {
            return;
        }
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
        Console.Write("\nSelect a student number (0: Cancel): ");

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

        Console.Write("\nSelect a department number (0: Cancel): ");
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

        Console.WriteLine("Existing Students:\n");
        var students = _studentsRepo.GetAllSudents();
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {students[i].Name} {students[i].Surname}");
        }

        Console.Write("\nSelect a student number (0: Back): ");
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

        Console.WriteLine("Existing Lectures:\n");
        var lectures = _lecturesRepo.GetAllLectures();
        for (int i = 0; i < lectures.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {lectures[i].Name}");
        }

        Console.Write("\nSelect a lecture number (0: Back): ");
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

        Console.WriteLine("Existing Departments:\n");
        var departments = _departmentsRepo.GetAllDepartments();
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect a department number (0: Back): ");
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

    private void PrintStudentsByDepartment()
    {
        Console.Clear();

        Console.WriteLine("=== View Students by Department ===\n");
        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("No departments exist yet.");
            return;
        }

        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect department number (0: Back): ");
        if (int.TryParse(PromptInput(), out int depIndex) &&
            depIndex >= 1 && depIndex <= departments.Count)
        {
            int depId = departments[depIndex - 1].Id;
            string depName = departments[depIndex - 1].Name;

            var students = _studentsRepo.GetStudentsByDepartment(depId);
            if (!students.Any())
            {
                Console.WriteLine($"\nNo students found in department: {depName}");
                return;
            }

            Console.Clear();

            Console.WriteLine($"Students in Department: {depName}\n");
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name} {student.Surname}");
            }
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

    private void PrintLecturesByDepartment()
    {
        Console.Clear();

        Console.WriteLine("=== View Lectures by Department ===\n");
        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("No departments exist yet.");
            return;
        }

        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect department number (0: Back): ");
        if (int.TryParse(PromptInput(), out int depIndex) &&
            depIndex >= 1 && depIndex <= departments.Count)
        {
            int depId = departments[depIndex - 1].Id;
            string depName = departments[depIndex - 1].Name;

            var lectures = _lecturesRepo.GetLecturesByDepartment(depId);
            if (!lectures.Any())
            {
                Console.WriteLine($"\nNo lectures found in department: {depName}");
                return;
            }

            Console.Clear();

            Console.WriteLine($"Lectures in Department: {depName}\n");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"Lecture: {lecture.Name}");
            }
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

    private void PrintLecturesByStudent()
    {
        Console.Clear();

        Console.WriteLine("=== View Lectures by Student ===\n");
        var students = _studentsRepo.GetAllSudents();
        if (!students.Any())
        {
            Console.WriteLine("No students exist yet.");
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {students[i].Name} {students[i].Surname}");
        }

        Console.Write("\nSelect student number (0: Back): ");
        if (int.TryParse(PromptInput(), out int studIndex) &&
            studIndex >= 1 && studIndex <= students.Count)
        {
            int studId = students[studIndex - 1].Id;
            string studName = students[studIndex - 1].Name;
            string studSurname = students[studIndex - 1].Surname;

            var lectures = _lecturesRepo.GetLecturesByStudent(studId);
            if (!lectures.Any())
            {
                Console.WriteLine($"\nNo lectures found for the student: {studName} {studSurname}");
                return;
            }

            Console.Clear();

            Console.WriteLine($"Lectures related to student: {studName} {studSurname}\n");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"Lecture: {lecture.Name}");
            }
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
}