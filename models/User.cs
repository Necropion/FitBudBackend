using System.ComponentModel.DataAnnotations;

namespace Backend.models;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    // Foreign Key
    [Required]
    public int RoleId { get; set; } = default!;

    [Required]
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    
    // Navigation Prop
    public Role Role { get; set; } = null!;

    // Inverse Navigation Prop
    public List<Exercise> Exercises { get; set; } = new();
}
