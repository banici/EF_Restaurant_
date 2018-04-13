using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Some.Domain;

namespace Some.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<SignatureDish> SignatureDishes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ChefSignatureDish> ChefSignatureDishes { get; set; }
        public DbSet<RestaurantSignatureDish> RestaurantSignatureDishes { get; set; }

        public static readonly LoggerFactory RestaurantLoggerFactory
            = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true)
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChefSignatureDish>().HasKey(m => new { m.ChefId, m.SignatureDishId });
            modelBuilder.Entity<RestaurantSignatureDish>().HasKey(m => new { m.RestaurantId, m.SignatureDishId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .EnableSensitiveDataLogging()
                 .UseLoggerFactory(RestaurantLoggerFactory)
                 .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = RestaurantDb; Trusted_Connection = True;");
        }
    }
}
