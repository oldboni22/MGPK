using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public record Faculty
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("faculty_id")]
    public int FacultyId { get; init; }
    
    [Column("faculty_name")]
    [Required]
    public string? Name { get; init; }
    
    public IEnumerable<Group>? Groups { get; set; }
}