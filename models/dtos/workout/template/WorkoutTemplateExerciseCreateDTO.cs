using System.ComponentModel.DataAnnotations;

namespace Backend.models.dtos;

public class WorkoutTemplateExerciseCreateDTO
{
    public Guid WorkoutTemplateId { get; set; } = default!;
    public Guid ExerciseId { get; set; } = default!;
    public int? Order { get; set; }
    public int? Sets { get; set; }
    public int? Reps { get; set; }
    public DateTime? Finished_at { get; set; }
}