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
    }
}
