namespace Backend.models.dtos;

public class ExerciseCreateDTO
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public Guid? UserId { get; set; }
}