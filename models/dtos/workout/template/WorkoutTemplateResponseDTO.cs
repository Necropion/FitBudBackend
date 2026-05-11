namespace Backend.models.dtos;

public class WorkoutTemplateResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? User { get; set; }
    public DateTime Created_at { get; set; }
}