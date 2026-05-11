using Backend.models;
using Backend.services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.controllers;

[ApiController]
[Route("api/role")]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }

    // Get Role List
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
    {
        var roles = await _roleService.FetchAllRoles();

        return Ok(roles);
    }

    [HttpPost]
    public async Task<ActionResult<Role>> PostRole(Role role)
    {
        var newRole = await _roleService.CreateRole(role);

        if (role == null)
        {
            return BadRequest("Failed to create user");
        }

        return Ok(newRole);
    }
}