using Microsoft.AspNetCore.Mvc;
using Backend.models;

namespace Backend.controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    // Get User List
    [HttpGet]
    public ActionResult<User> GetUsers()
    {
        var user = new User
        {
            Id = 1,
            Name = "Bob"
        };

        return Ok(user);
    }
}