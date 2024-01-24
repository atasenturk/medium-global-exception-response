using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ResponseModelWebApi.DTOs;
using ResponseModelWebApi.Exceptions;
using ResponseModelWebApi.Models;
using ResponseModelWebApi.Repositories.GenericRepository;
using ResponseModelWebApi.Repositories.Interfaces;
using ResponseModelWebApi.Services.Interfaces;

namespace ResponseModelWebApi.Services;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = await userRepository.GetAll();
        var mapped = mapper.Map<List<UserDto>>(users);
        return mapped;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await userRepository.GetById(id);
        var mapped = mapper.Map<UserDto>(user);
        return mapped ?? throw new NotFoundException($"User with id {id} is not found!");
    }

    public async Task<UserDto> CreateUser(CreateUserDto user)
    {
        var mapped = mapper.Map<User>(user);
        var createdUser = await userRepository.Create(mapped);
        var createdMapped = mapper.Map<UserDto>(createdUser);
        return createdMapped;
    }

    public async Task UpdateUser(UpdateUserDto user)
    {
        var userDmo = await userRepository.GetById(user.Id);
        if (userDmo == null)
            throw new NotFoundException($"User with id {user.Id} is not found!");

        var mapped = mapper.Map(user, userDmo);
        userRepository.Update(mapped);
    }

    public async Task DeleteUser(int id)
    {
        var usedToDelete = await userRepository.GetById(id);
        if (usedToDelete == null)
            throw new NotFoundException($"User with id {id} is not found!");

        await userRepository.Delete(id);
    }
}