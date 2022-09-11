using Core.Entity.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagementSystem.Entity.Concrete;
using System.Reflection.Emit;

namespace StudentManagementSystem.DataAccess.Context
{
    public class StudentManagementSystemDbContext : DbContext
    {
        public StudentManagementSystemDbContext()
        {
            #region PostgreSQL EnableLegacyTimestampBehavior
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(getConnectionString("PostgreSql"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role[] roleEntitySeeds =
            {
                new (){Id=1,RoleName="Admin"},
                new (){Id=2,RoleName="Teacher"},
                new (){Id=3,RoleName="Student"}
            };

            modelBuilder.Entity<Role>().HasData(roleEntitySeeds);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("12345", out passwordHash, out passwordSalt);
            User[] userEntitySeeds = {
                new() {Id=1,RoleId=1,
                    FirstName="AdminFN",LastName="LN",
                    Email="admin@hotmail.com",
                    PasswordHash=passwordHash,
                    PasswordSalt=passwordSalt }
            };

            modelBuilder.Entity<User>().HasData(userEntitySeeds);
        }
        

        private string getConnectionString(string name)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configurationManager = builder.Build();

            return configurationManager.GetConnectionString(name);
        }
    }
}
