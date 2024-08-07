using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DealMate
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
