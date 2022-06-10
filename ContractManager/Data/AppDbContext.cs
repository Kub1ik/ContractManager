using ContractManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContractManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Adviser> Advisers { get; set; }
        public DbSet<ContractAdviser> ContractAdvisers { get; set; }
    }
}
