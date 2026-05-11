namespace Backend.models.dtos;

public class WorkoutTemplateCreateDTO
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public Guid? UserId { get; set; }
    public DateTime Created_at { get; set; }
}