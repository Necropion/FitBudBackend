using Backend.models;
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
    public async Task<IEnumerable<User>> FetchAllUsers()
    {
        return await _databaseContext.Users.ToListAsync();
    }

    // Create User
    public async Task<User> CreateUser(User user)
    {
        _databaseContext.Users.Add(user);
        await _databaseContext.SaveChangesAsync();

        return user;
    }
}