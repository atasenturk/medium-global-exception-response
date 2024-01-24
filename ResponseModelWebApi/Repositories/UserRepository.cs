using Microsoft.EntityFrameworkCore;
using ResponseModelWebApi.Models;
using ResponseModelWebApi.Repositories.GenericRepository;
using ResponseModelWebApi.Repositories.Interfaces;

namespace ResponseModelWebApi.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ResponseModelWebApiContext _context;
        public UserRepository(ResponseModelWebApiContext context) : base(context)
        {
            _context = context;
        }

        public Task<User?> Login(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
