using System;
using System.Linq;
using LearningPlatformWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NodaTime;
using Npgsql;

namespace LearningPlatformWebAPI
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoice> QuestionChoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"), 
                o => o.UseNodaTime());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ModelBase && e.State is EntityState.Added or EntityState.Modified);
            
            foreach (var entityEntry in entries)
            {
                ((ModelBase) entityEntry.Entity).UpdatedAt = LocalDateTime.FromDateTime(DateTime.Now);
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((ModelBase)entityEntry.Entity).CreatedAt = LocalDateTime.FromDateTime(DateTime.Now);
                        break;
                    case EntityState.Deleted:
                        ((ModelBase)entityEntry.Entity).DeletedAt = LocalDateTime.FromDateTime(DateTime.Now);
                        break;
                }
            }
            
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(r => r.Roles)
                .WithMany(u => u.Users);

            modelBuilder.Entity<Classroom>()
                .HasMany(r => r.Participants)
                .WithMany(u => u.Classrooms);
            
            
            modelBuilder.Entity<Classroom>();
            

            base.OnModelCreating(modelBuilder);
        }
    }
}