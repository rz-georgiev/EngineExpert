using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineExpert.Data.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

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



    }
}
