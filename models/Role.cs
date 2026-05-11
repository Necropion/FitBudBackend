using System.ComponentModel.DataAnnotations;

namespace Backend.models;

public class Role
{
    [Key]
    public int Id { get; set;}

    [Required]
    public string Name { get; set; } = default!;

    // Inverse Navigation Prop
    public List<User> Users { get; set; } = new();
}