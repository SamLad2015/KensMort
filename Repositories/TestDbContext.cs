using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pertemps.Entities;

namespace Pertemps.Repositories
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
           : base(options)
        {

        }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<CandidateEntity> Candidates { get; set; }
        public DbSet<CandidateSkillEntity> CandidateSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillEntity>()
                .Property(c => c.Id)
                .IsRequired();
            modelBuilder.Entity<CandidateEntity>()
                .Property(r => r.Id)
                .IsRequired();
            modelBuilder.Entity<CandidateSkillEntity>()
                .Property(r => r.Id)
                .IsRequired();

            modelBuilder.Entity<CandidateSkillEntity>()
                .HasOne<CandidateEntity>(cs => cs.Candidate)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CandidateId);


            modelBuilder.Entity<CandidateSkillEntity>()
                .HasOne<SkillEntity>(cs => cs.Skill)
                .WithMany(s => s.Skills)
                .HasForeignKey(cs => cs.SkillId);
            
        }
    }
}
