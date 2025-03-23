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
    public string? Name { get; set; }
    
    [ForeignKey(nameof(Group))]
    [Column("group_id")]
    public int GroupId { get; init; }
    public Group? Group { get; init; }
}