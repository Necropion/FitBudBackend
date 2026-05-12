using System.ComponentModel.DataAnnotations;

namespace Backend.models;

public class WorkoutTemplateExercise
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid WorkoutTemplateId { get; set; } = default!;

    [Required]
    public Guid ExerciseId { get; set; } = default!;

    public int? Order { get; set; }

    public int? Sets { get; set; }

    public int? Reps { get; set; }

    [Required]
    public DateTime Created_at { get; set; } = DateTime.UtcNow;

    public DateTime? Finished_at { get; set; }

    // Navigation Prop
    public WorkoutTemplate WorkoutTemplate { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;

}