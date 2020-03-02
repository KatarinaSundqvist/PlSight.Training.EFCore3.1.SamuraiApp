using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

namespace SamuraiApp.Data {
    public class SamuraiContext : DbContext {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder => {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole();
        });


        // Hard-coded connection string. Just for demo and first looks!
        // For real software, use dependency injection
        // The EnableSensitiveDataLogging is also only for internal use! Be careful!
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SamuraiAppDataCore");
        }

        // Here we are using Fluent API to specify the last critical detail of
        // the many-to-many relationship between Battles and Samurais
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
            // EF Core will find the Horse class without it having a DbSet property
            // because it's linked to the Samurai class
            // but it would name the table Horse, so we change that here
            // (our business rules don't want anyone to be able to interact directly with the horse class, so we don't want to expose it via DbSet)
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");
            // the first part shows that it is intentional that this entity doesn't have a key
            // The second part is to tell the application that there is already a view for this entity. Otherwise, the next migration we apply will try to create a table
            // HasNoKey entities will never be tracked by EF Core, and if you try to force it with AsTracking, EF Core will ignore your attempt
        }
    }
}
