using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data {
    public class SamuraiContext : DbContext {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }

        // Hard-coded connection string. Just for demo and first looks!
        // For real software, use dependency injection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SamuraiAppDataCore");
        }
        
        // Here we are using Fluent API to specify the las critical detail of
        // the many-to-many relationship between Battles and Samurais
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
