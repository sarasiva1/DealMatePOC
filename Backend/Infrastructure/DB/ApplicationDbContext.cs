using DealMate.Backend.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DealMate.Backend.Infrastructure.DB
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
