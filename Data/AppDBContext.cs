using Microsoft.EntityFrameworkCore;
using PremiumCalculatorApp.Models;

namespace PremiumCalculatorApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<RatingFactor> RatingFactors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occupation>().ToTable("Occupation");
            modelBuilder.Entity<RatingFactor>().ToTable("RatingFactor");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<RatingFactor>().HasData(
                new RatingFactor
                {
                    RatingId = 1,
                    Rating = "Professional",
                    Factor = 1.0
                },
                new RatingFactor
                {
                    RatingId = 2,
                    Rating = "White Collar",
                    Factor = 1.25
                },
                 new RatingFactor
                 {
                     RatingId = 3,
                     Rating = "Light Manual",
                     Factor = 1.50
                 },
                new RatingFactor
                {
                    RatingId = 4,
                    Rating = "Heavy Manual",
                    Factor = 1.75
                });

            modelBuilder.Entity<Occupation>().HasData(
                new Occupation
                {
                    OccupationId = 1,
                    OccupationName = "Cleaner",
                    RatingId = 3
                },
                new Occupation
                {
                    OccupationId = 2,
                    OccupationName = "Doctor",
                    RatingId = 1
                },
                new Occupation
                {
                    OccupationId = 3,
                    OccupationName = "Author",
                    RatingId = 2
                },
                new Occupation
                {
                    OccupationId = 4,
                    OccupationName = "Farmer",
                    RatingId = 4
                },
                new Occupation
                {
                    OccupationId = 5,
                    OccupationName = "Mechanic",
                    RatingId = 4
                },
                new Occupation
                {
                    OccupationId = 6,
                    OccupationName = "Florist",
                    RatingId = 3
                });
        }
    }
}
