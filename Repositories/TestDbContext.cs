using System;
using System.Collections.Generic;
using KensMort.Entities;
using Microsoft.EntityFrameworkCore;

namespace KensMort.Repositories
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
           : base(options)
        {

        }
        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<ScenarioEntity> Scenarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanEntity>()
                .Property(c => c.Id)
                .IsRequired();
            modelBuilder.Entity<ScenarioEntity>()
                .Property(r => r.Id)
                .IsRequired();
        }
    }
}
