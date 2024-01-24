using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseModelWebApi.DTOs;
using ResponseModelWebApi.Exceptions;
using ResponseModelWebApi.Models;
using ResponseModelWebApi.Models.Response;
using ResponseModelWebApi.Services.Interfaces;

namespace ResponseModelWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return Ok(new ApiResponse<List<UserDto>>
        {
            Data = users,
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.OK,
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);
        return Ok(new ApiResponse<UserDto>
        {
            Data = user,
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.OK,
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
    {
        var createdUser = await userService.CreateUser(user);
        return Created("/api/user", new ApiResponse<UserDto>
        {
            Data = createdUser,
            IsSuccess = true,
            StatusCode = (int)HttpStatusCode.Created,
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto user)
    {
        await userService.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await userService.DeleteUser(id);
        return NoContent();
    }
}