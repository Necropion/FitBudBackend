using System.ComponentModel.DataAnnotations;

namespace Backend.models;

public class WorkoutTemplate
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public Guid? UserId { get; set; }

    [Required]
    public DateTime Created_at { get; set; } = DateTime.UtcNow;

    // Navigation Prop
    public User? User { get; set; }

    // Inverse Navigation Prop
    public List<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; } = new();
}