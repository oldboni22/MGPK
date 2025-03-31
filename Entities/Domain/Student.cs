using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public record Student
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("student_id")]
    public int Id { get; init; }
    
    [Column("student_name")]
    [Required]
    public string? Name { get; init; }
    
    [ForeignKey(nameof(Group))]
    [Column("group_id")]
    public int GroupId { get; init; }
    public Group Group { get; set; } = new();
    
    [ForeignKey(nameof(Faculty))]
    [Column("faculty_id")]
    public int FacultyId { get; init; }

    public Faculty Faculty { get; set; } = new();

}