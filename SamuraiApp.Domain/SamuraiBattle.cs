namespace SamuraiApp.Domain {
    // This class is here for the many-to-many join between Samurai and Battle
    // The Ids are required, as they are the foreign keys
    // The navigations are optional for EF Core, but are there for coding convenience

    public class SamuraiBattle {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }
}
