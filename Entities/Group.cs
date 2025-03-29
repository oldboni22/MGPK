using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public record Group
{
    [Column("group_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    
    [Column("group_name")]
    [Required]
    public string? GroupName { get; init; }

    [ForeignKey(nameof(Faculty))]
    [Column("faculty_id")]
    public int FacultyId { get; init; }

    public Faculty Faculty { get; init; } = new();

    public IEnumerable<Student> Students { get; set; } = [];
}