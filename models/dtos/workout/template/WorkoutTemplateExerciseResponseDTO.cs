using System.ComponentModel.DataAnnotations;

namespace Backend.models.dtos;

public class WorkoutTemplateExerciseResponseDTO
{
    public Guid Id { get; set; } = default!;
    public string WorkoutTemplate { get; set; } = null!;
    public ExerciseResponseDTO Exercise { get; set; } = null!;
    public int? Order { get; set; }
    public int? Sets { get; set; }
    public int? Reps { get; set; }
    public DateTime Created_at { get; set; } = default!;
    public DateTime? Finished_at { get; set; }

}