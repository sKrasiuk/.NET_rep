using System.ComponentModel.DataAnnotations;

namespace DB_Atsiskaitymas.Models;

public class Lecture
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Department> Departments { get; set; } = new List<Department>();
    public List<Student> Students { get; set; } = new List<Student>();

    public Lecture(string name)
    {
        Name = name;
    }
}
