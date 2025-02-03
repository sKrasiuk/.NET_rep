using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Atsiskaitymas.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid PersonalCode { get; set; } = Guid.NewGuid();

    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public List<Lecture> Lectures { get; set; } = new List<Lecture>();
}
