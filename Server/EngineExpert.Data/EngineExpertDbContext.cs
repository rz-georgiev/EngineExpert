using EngineExpert.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineExpert.Data
{
    public class EngineExpertDbContext : DbContext
    {
        public EngineExpertDbContext(DbContextOptions<EngineExpertDbContext> options)
          : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientCar> ClientsCars { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UsersRoles { get; set; }
    }
}