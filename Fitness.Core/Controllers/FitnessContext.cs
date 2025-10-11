using Fitness.Core.Entities;
using System.Data.Entity;

namespace Fitness.Core.Controllers
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("FitnessConnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
