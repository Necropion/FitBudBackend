using Backend.models;
using Backend.models.dtos;
using FitBudBackend.data;
using Microsoft.EntityFrameworkCore;

namespace Backend.services;

public class UserService
{
    private readonly DatabaseContext _databaseContext;

    public UserService(DatabaseContext context)
    {
        _databaseContext = context;
    }

    // Fetch All Users
    public async Task<IEnumerable<UserResponseDTO>> FetchAllUsers()
    {
        var users = await _databaseContext.Users
            .Include(u => u.Role)
            .Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Role = u.Role.Name
            })
            .ToListAsync();
        
        return users;
    }

    // Find Single User By ID
    public async Task<UserResponseDTO?> FindUserByID(Guid userID)
    {
        var userFound = await _databaseContext.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.Id == userID);

        if (userFound == null)
        {
            return null;
        }

        var user = new UserResponseDTO
        {
            Id = userFound.Id,
            Name = userFound.Name,
            Role = userFound.Role.Name
        };

        return user;
    }

    // Create User
    public async Task<UserResponseDTO> CreateUser(UserCreateDTO userCreateDTO)
    {
        var newUser = new User
        {
            Name = userCreateDTO.Name,
            RoleId = 1
        };

        _databaseContext.Users.Add(newUser);
        await _databaseContext.SaveChangesAsync();

        return await FindUserByID(newUser.Id);
    }
}