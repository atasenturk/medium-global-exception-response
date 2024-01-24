using ResponseModelWebApi.Models;
using ResponseModelWebApi.Repositories.GenericRepository;

namespace ResponseModelWebApi.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> Login(string email);
    }
}
