using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DongHoLePhuocHai.Models;

namespace DongHoLePhuocHai.Api.Models;

public class FamilyMember
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int? BirthYear { get; set; }

    public int? DeathYear { get; set; }

    public bool IsAlive { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public int? ParentId { get; set; }

    public int Generation { get; set; }

    [ForeignKey("ParentId")]
    public FamilyMember? Parent { get; set; }

    public List<FamilyMember> Children { get; set; } = new();
} 