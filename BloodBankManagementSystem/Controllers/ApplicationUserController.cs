using BLL.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(ApplicationUserViewModel user)
    {
        var createdUser = await _userService.CreateUserAsync(user);
        return Ok(createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, ApplicationUserViewModel user)
    {
        if (id != user.Id)
        {
            return BadRequest("User ID mismatch");
        }

        var result=await _userService.UpdateUserAsync(user);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var result=await _userService.DeleteUserAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}

