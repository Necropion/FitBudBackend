using Backend.models;
using FitBudBackend.data;
using Microsoft.EntityFrameworkCore;

namespace Backend.services;

public class RoleService
{
    private readonly DatabaseContext _databaseContext;

    public RoleService(DatabaseContext context)
    {
        _databaseContext = context;
    }

    // Fetch All Roles
    public async Task<IEnumerable<Role>> FetchAllRoles()
    {
        return await _databaseContext.Roles.ToListAsync();
    }

    // Create Role
    public async Task<Role> CreateRole(Role role)
    {
        _databaseContext.Roles.Add(role);
        await _databaseContext.SaveChangesAsync();

        return role;
    }
}