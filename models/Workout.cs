using System.ComponentModel.DataAnnotations;

namespace Backend.models;

public class Workout
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? Notes { get; set; }

}