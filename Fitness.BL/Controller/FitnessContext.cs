using Fitness.BL.Logic;
using Fitness.BL.Model;
using System.Data.Entity;

namespace Fitness.BL.Controller
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnetcion") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
