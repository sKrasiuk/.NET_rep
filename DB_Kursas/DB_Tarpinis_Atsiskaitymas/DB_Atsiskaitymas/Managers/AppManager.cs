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
            Console.WriteLine("2: Create / Manage Lecture (requires Department)");
            Console.WriteLine("3: Create / Manage Student (requires Department)");
            Console.WriteLine("4: Refresh Database (reqiured after Lecture addition / alteration)");
            Console.WriteLine("5: Access Records");
            Console.WriteLine("6: Delete entities");
            Console.WriteLine("0: Exit");
            Console.Write("\nSelect an option: ");

            switch (PromptInput())
            {
                case "1":
                    CreateDepartment();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("1: Create Lecture (requires Department)");
                    Console.WriteLine("2: Manage Lectures");
                    Console.Write("\nSelect a lecture number (0: Cancel): ");

                    switch (PromptInput())
                    {
                        case "1":
                            CreateLecture();
                            break;
                        case "2":
                            ManageLecture();
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
                    Console.WriteLine("2: Manage Students");
                    Console.Write("\nSelect a student number (0: Cancel): ");

                    switch (PromptInput())
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

                    switch (PromptInput())
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

                    switch (PromptInput())
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

        Console.Write($"\nCreate student {name} {surname}? (Y/N): ");
        string confirm = PromptInput().ToLower();
        if (!confirm.Equals("y"))
        {
            Console.WriteLine($"\nStudent {name} {surname} - Cancelled.");
            return;
        }

        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("\nNo departments exist yet. Create one before assigning.");
            return;
        }
        _studentsRepo.AddStudent(name, surname);

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
        Console.WriteLine("=== Change Student Department ===\n");

        var students = _studentsRepo.GetAllSudents();
        if (!students.Any())
        {
            Console.WriteLine("No students found. Please create a student first.");
            return;
        }

        Console.WriteLine("Available Students:\n");
        for (int i = 0; i < students.Count; i++)
        {
            var student = students[i];
            Console.WriteLine($"{i + 1}: {student.Name} {student.Surname}");
            Console.WriteLine($"\tCurrent Department: {student.Department?.Name ?? "None"}");
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

        Console.Clear();
        Console.WriteLine($"=== Managing Student: {sName} {sSurname} ===\n");
        Console.WriteLine("1: Change department (and inherit lectures)");
        Console.WriteLine("2: Clear all dependencies (department and lectures)");
        Console.WriteLine("0: Cancel");

        Console.Write("\nSelect an option: ");
        string choice = PromptInput();

        switch (choice)
        {
            case "1":
                ChangeDepartment(sName, sSurname);
                break;
            case "2":
                ClearStudentDependencies(sName, sSurname);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }

    private void ChangeDepartment(string studentName, string studentSurname)
    {
        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("No departments available. Create one first.");
            return;
        }

        Console.WriteLine("\nAvailable Departments:");
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        Console.Write("\nSelect a department number (0: Cancel): ");
        if (!int.TryParse(PromptInput(), out int depIndex) || depIndex < 0 || depIndex > departments.Count)
        {
            Console.WriteLine("Invalid department selection.");
            return;
        }
        if (depIndex == 0)
        {
            return;
        }

        string depName = departments[depIndex - 1].Name;
        _studentsRepo.SetDepartment(studentName, studentSurname, depName, assignLectures: true);
    }

    private void ClearStudentDependencies(string studentName, string studentSurname)
    {
        Console.Write($"\nAre you sure you want to clear all dependencies for student {studentName} {studentSurname}? (Y/N): ");
        if (PromptInput().ToLower() != "y")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        _studentsRepo.ClearDependencies(studentName, studentSurname);
        Console.WriteLine($"\nAll dependencies cleared for student: {studentName} {studentSurname}");
    }

    private void CreateLecture()
    {
        Console.Clear();

        Console.Write("Enter Lecture Name (0: Cancel): ");
        string lectureName = PromptInput();
        if (lectureName == "0")
        {
            return;
        }

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

    private void ManageLecture()
    {
        Console.Clear();
        Console.WriteLine("=== Manage Lecture Departments ===\n");

        var lectures = _lecturesRepo.GetAllLectures();
        if (!lectures.Any())
        {
            Console.WriteLine("No lectures exist yet. Create a lecture first.");
            return;
        }

        Console.WriteLine("Available Lectures:\n");
        for (int i = 0; i < lectures.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {lectures[i].Name}");

            if (!lectures[i].Departments.Any())
            {
                Console.WriteLine("\tNot related to any Department.");
            }
            else
            {
                foreach (var department in lectures[i].Departments)
                {
                    Console.WriteLine($"\tDepartment: {department.Name}");
                }
            }
        }

        Console.Write("\nSelect a lecture number (0: Back): ");
        if (!int.TryParse(PromptInput(), out int lecIndex) ||
            lecIndex < 1 || lecIndex > lectures.Count)
        {
            if (lecIndex != 0)
            {
                Console.WriteLine("Invalid lecture selection.");
            }
            return;
        }

        string lectureName = lectures[lecIndex - 1].Name;

        Console.Clear();
        Console.WriteLine($"=== Managing Lecture: {lectureName} ===\n");
        Console.WriteLine("1: Manage existing department relations");
        Console.WriteLine("2: Reset and reassign all department relations");
        Console.WriteLine("0: Back");
        Console.Write("\nSelect an option: ");

        switch (PromptInput())
        {
            case "1":
                ManageLectureDepartments(lectureName);
                break;
            case "2":
                ResetAndReassignDepartments(lectureName);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }

    private void ManageLectureDepartments(string lectureName)
    {
        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("\nNo departments exist yet. Create one before assigning.");
            return;
        }

        Console.WriteLine("\nAvailable Departments:\n");
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        while (true)
        {
            Console.Write("\nSelect a department number (0: Finish): ");
            string input = PromptInput();

            if (input == "0")
            {
                break;
            }

            if (int.TryParse(input, out int depIndex) &&
                depIndex >= 1 && depIndex <= departments.Count)
            {
                string depName = departments[depIndex - 1].Name;
                _lecturesRepo.SetDepartment(lectureName, depName);
            }
            else
            {
                Console.WriteLine("\nInvalid department number. Try again.");
            }
        }
    }

    private void ResetAndReassignDepartments(string lectureName)
    {
        Console.Write($"\nAre you sure you want to reset all department relations for lecture {lectureName}? (Y/N): ");
        if (PromptInput().ToLower() != "y")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        var departments = _departmentsRepo.GetAllDepartments();
        if (!departments.Any())
        {
            Console.WriteLine("\nNo departments exist yet. Create one before assigning.");
            return;
        }

        _lecturesRepo.ClearDepartmentRelations(lectureName);

        Console.WriteLine("\nAvailable Departments:");
        for (int i = 0; i < departments.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {departments[i].Name}");
        }

        while (true)
        {
            Console.Write("\nSelect department numbers to assign (0: Finish): ");
            string input = PromptInput();

            if (input == "0")
            {
                break;
            }

            if (int.TryParse(input, out int depIndex) &&
                depIndex >= 1 && depIndex <= departments.Count)
            {
                string depName = departments[depIndex - 1].Name;
                _lecturesRepo.SetDepartment(lectureName, depName);
            }
            else
            {
                Console.WriteLine("\nInvalid department number. Try again.");
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