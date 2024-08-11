﻿using DealMate.Backend.Domain.Aggregates;
using DealMate.BackEnd.Domain.Aggregates;
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

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
