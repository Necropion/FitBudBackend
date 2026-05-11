using Microsoft.EntityFrameworkCore;
using Backend.models;

namespace FitBudBackend.data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WeightUnit> WeightUnits { get; set; }
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}