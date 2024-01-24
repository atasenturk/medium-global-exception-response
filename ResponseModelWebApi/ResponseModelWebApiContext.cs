using Microsoft.EntityFrameworkCore;
using ResponseModelWebApi.Models;

namespace ResponseModelWebApi
{
    public class ResponseModelWebApiContext : DbContext
    {
        public ResponseModelWebApiContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com" });
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ResponseModelDb;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
}