namespace DongHoLePhuocHai.Models;

public class FamilyMemberDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? BirthYear { get; set; }
    public int? DeathYear { get; set; }
    public bool IsAlive { get; set; }
    public Gender Gender { get; set; }
    public int? ParentId { get; set; }
    public string ParentName { get; set; }
    public int Generation { get; set; }
} 