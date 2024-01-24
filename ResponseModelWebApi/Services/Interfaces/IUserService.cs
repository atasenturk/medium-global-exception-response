using ResponseModelWebApi.DTOs;
using ResponseModelWebApi.Models;

namespace ResponseModelWebApi.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsers();
    Task<UserDto> GetUserById(int id);
    Task<UserDto> CreateUser(CreateUserDto user);
    Task UpdateUser(UpdateUserDto user);
    Task DeleteUser(int id);
}