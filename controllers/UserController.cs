using Microsoft.AspNetCore.Mvc;
using Backend.models;
using Backend.services;
using Backend.models.dtos;

namespace Backend.controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // Get User List
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsers()
    {
        var users = await _userService.FetchAllUsers();

        return Ok(users);
    }

    // Post Single User
    [HttpPost]
    public async Task<ActionResult<UserResponseDTO>> PostUser(UserCreateDTO userCreateDTO)
    {
        var newUser = await _userService.CreateUser(userCreateDTO);

        if (newUser == null)
        {
            return BadRequest("Failed to create user");
        }

        return Ok(newUser);
    }
}