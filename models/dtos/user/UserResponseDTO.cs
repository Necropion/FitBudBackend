namespace Backend.models.dtos;

public class UserResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Role { get; set; } = null!;

}