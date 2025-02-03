using System.ComponentModel.DataAnnotations;

namespace DB_Atsiskaitymas.Models;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Student> Students { get; set; } = new List<Student>();
    public List<Lecture> Lectures { get; set; } = new List<Lecture>();

    public Department(string name)
    {
        Name = name;
    }
}
