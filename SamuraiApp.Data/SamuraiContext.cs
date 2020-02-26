using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data {
    public class SamuraiContext : DbContext {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }

        // Hard-coded connection string. Just for demo and first looks!
        // For real software, use dependency injection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SamuraiAppDataCore");
        }
        
        // Here we are using Fluent API to specify the las critical detail of
        // the many-to-many relationship between Battles and Samurais
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
            // EF Core will find the Horse class without it having a DbSet property
            // because it's linked to the Samurai class
            // but it would name the table Horse, so we change that here
            // (our business rules don't want anyone to be able to interact directly with the horse class, so we don't want to expose it via DbSet)
        }
    }
}
