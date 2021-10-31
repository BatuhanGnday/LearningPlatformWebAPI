using System;
using System.Linq;
using EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using LearningPlatformWebAPI.Database.Models;
using LearningPlatformWebAPI.Database.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NodaTime;

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
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // optionsBuilder.UseSqlServer(
            //     configuration.GetConnectionString("DefaultConnection"),
            //     o => o.UseNodaTime()
            // );
            
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                o => o.UseNodaTime());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ModelBase &&
                            e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);

            foreach (var entityEntry in entries)
            {
                ((ModelBase) entityEntry.Entity).UpdatedAt = LocalDateTime.FromDateTime(DateTime.Now);
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((ModelBase) entityEntry.Entity).CreatedAt = LocalDateTime.FromDateTime(DateTime.Now);
                        break;
                    case EntityState.Deleted:
                        ((ModelBase) entityEntry.Entity).DeletedAt = LocalDateTime.FromDateTime(DateTime.Now);
                        break;
                    case EntityState.Modified:
                        ((ModelBase) entityEntry.Entity).UpdatedAt = LocalDateTime.FromDateTime(DateTime.Now);
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}