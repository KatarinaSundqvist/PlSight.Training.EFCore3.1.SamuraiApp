using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp {
    internal class Program {

        // NOTE: This is just for demo, very simple! 
        // NOT best practise, not recommended for use in real software!

        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args) {
            InsertMultipleSamurais();
        }

        private static void InsertMultipleSamurais() {
            //var samurai = new Samurai { Name = "Sampson" };
            //var samurai2 = new Samurai { Name = "Tasha" };
            //var samurai3 = new Samurai { Name = "Number3" };
            //var samurai4 = new Samurai { Name = "Number4" };
            var _bizdata = new BusinessDataLogic();
            var samuraiNames = new string[] { "Sampson", "Tasha", "Number3", "Number4" };
            var newSamuraisCreated = _bizdata.AddMultipleSamurais(samuraiNames);
        }

        #region RawSQL
        //static void Main(string[] args) {
        //    //QuerySamuraiBattleStats();
        //    //QueryUsingRawSql();
        //    //QueryUsingRawSqlWithInterpolation();
        //    //DANGERDANGERQueryUsingRawSqlWithInterpolation();
        //    //QueryUsingFromRawSqlStoredProc();
        //    //InterpolatedRawSqlQueryStoredProc();
        //    ExecuteSomeRawSql();

        //}

        //private static void ExecuteSomeRawSql() {
        //    var samuraiId = 17;
        //    //// Raw. Remember to use string formatting, using a parameter!
        //    //var x = _context.Database
        //    //    .ExecuteSqlRaw("EXEC DeleteQuotesForSamurai {0}", samuraiId);
        //    // Interpolated:
        //    samuraiId = 18;
        //    _context.Database
        //        .ExecuteSqlInterpolated($"EXEC DeleteQuotesForSamurai {samuraiId}");

        //}

        //private static void InterpolatedRawSqlQueryStoredProc() {
        //    var text = "Happy";
        //    var samurais = _context.Samurais.FromSqlInterpolated(
        //        $"EXEC dbo.SamuraisWhoSaidAWord {text}").ToList();
        //}

        //private static void QueryUsingFromRawSqlStoredProc() {
        //    var text = "Happy";
        //    var samurais = _context.Samurais.FromSqlRaw(
        //        "EXEC dbo.SamuraisWhoSaidAWord {0}", text).ToList();
        //}

        //private static void DANGERDANGERQueryUsingRawSqlWithInterpolation() {
        //    string name = "Kikuchyo";
        //    var samurais = _context.Samurais
        //        .FromSqlRaw($"Select * from Samurais Where Name = {name}")
        //        .ToList();
        //    // If you pass an interpolated string into FromSqlRaw, it will first interpolate the string, then feed it to the database
        //    // Depending on how you format it, SQL might read your variable as a column name. This might lead you to add '' around it, and then you are suddenly in a situation where you have a non-parameterised query, and be vulnerable to SQL injection attack. 
        //    //So don't do this! Instead, always use FromSqlInterpolated if you are interpolating strings!
        //}

        //private static void QueryUsingRawSqlWithInterpolation() {
        //    string name = "Kikuchyo";
        //    var samurais = _context.Samurais
        //        .FromSqlInterpolated($"Select * from Samurais Where Name = {name}")
        //        .ToList();
        //}

        //private static void QueryUsingRawSql() {
        //    // simple example
        //    var samurais = _context.Samurais.FromSqlRaw("Select * from Samurais").ToList();
        //}

        //private static void QuerySamuraiBattleStats() {
        //    //var stats = _context.SamuraiBattleStats.ToList();
        //    //var firstStat = _context.SamuraiBattleStats.FirstOrDefault();
        //    //var sampsonStat = _context.SamuraiBattleStats
        //    //            .Where(s => s.Name == "SampsonSan").FirstOrDefault();
        //    //// The query below will fail at runtime, since there is no key
        //    //var findone = _context.SamuraiBattleStats.Find(2);

        //} 
        #endregion

        #region SimpleQueries
        //static void Main(string[] args) {
        //    //_context.Database.EnsureCreated();
        //    //GetSamurais("Before Add:");
        //    //InsertMultipleSamurais();
        //    //InsertVariousTypes();
        //    //AddSamurai();
        //    //GetSamuraisSimpler("After Add:");
        //    //Console.WriteLine("Press any key");
        //    //Console.ReadKey();
        //    //QueryFilters();
        //    //RetrieveAndUpdateSamurai();
        //    //RetrieveAndUpdateMultipleSamurais();
        //    //RetrieveAndDeleteSamurai();
        //    //InsertBattle();
        //    //QueryAndUpdateBattleDisconnected();
        //    //InsertNewSamuraiWithAQuote();
        //    //InsertNewSamuraiWithManyQuotes();
        //    //AddQuoteToExistingSamuraiWhileTracked();
        //    //AddQuoteToExistingSamuraiNotTracked(2);
        //    //AddQuoteToExistingSamuraiNotTracked_Easy(2);
        //    //EagerLoadSamuraiWithQuotes();
        //    //ProjectSomeProperties();
        //    //ProjectSamuraisWithQuotes();
        //    //ExplicitLoadQuotes();
        //    //LazyLoadQuotes();
        //    //FilteringWithRelatedData();
        //    //ModifyingRelatedDataWhenTracked();
        //    //ModifyingRelatedDataWhenNotTracked();
        //    //JoinBattleAndSamurai();
        //    //EnlistSamuraiIntoABattle();
        //    //RemoveJoinBetweenSamuraiAndBattleSimple();
        //    //GetSamuraiWithBattles();
        //    //AddNewSamuraiWithHorse();
        //    //AddNewHorseToSamuraiUsingId();
        //    //AddNewHorseToSamuraiObject();
        //    //AddNewHorseToDisconnectedSamuraiObject();
        //    //ReplaceAHorse();
        //    //GetSamuraisWithHorse();
        //    //GetHorseWithSamurai();
        //    //GetSamuraiWithClan();
        //    //GetClanWithSamurais();

        //}

        //// One-to-many relationship without foreign keys and navigation properties ("clean" classes:
        //private static void GetClanWithSamurais() {
        //    // Since we don't have a list of samurais property in the Clan class, we can't include the samurais on the clan (line below this)
        //    // var clan=_context.Clans.Include(c=>c.?????)
        //    // instead, first you have to get the clan, and then you have to get the samurais by drilling through the samurai's navigation property to the clan ID
        //    var clan = _context.Clans.Find(3);
        //    var samuraisForClan = _context.Samurais.Where(s => s.Clan.Id == 3).ToList();
        //}

        //private static void GetSamuraiWithClan() {
        //    // Easy enough, since we have the navigation property in the Samurai class:
        //    var samurai = _context.Samurais.Include(s => s.Clan).FirstOrDefault();
        //}

        //// One-to-one relationship:
        //private static void GetHorseWithSamurai() {
        //    // Since we have neither a Horse DbSet nor a samurai property in the Horse class, it's more complicated to get a Horse with its samurai. Three different ways:
        //    var horseWithoutSamurai = _context.Set<Horse>().Find(3);

        //    var horseWithSamurai = _context.Samurais.Include(s => s.Horse)
        //        .FirstOrDefault(s => s.Horse.Id == 3);

        //    var horsesWithSamurais = _context.Samurais
        //        .Where(s => s.Horse != null)
        //        .Select(s => new { Horse = s.Horse, Samurai = s })
        //        .ToList();
        //}

        //private static void GetSamuraisWithHorse() {
        //    // It's easy to get the horse included when querying samurais:
        //    var samurai = _context.Samurais.Include(s => s.Horse).ToList();
        //}

        //private static void ReplaceAHorse() {
        //    var samurai = _context.Samurais.Include(s => s.Horse).FirstOrDefault(s => s.Id == 14);
        //    samurai.Horse = new Horse { Name = "Trigger" };
        //    _context.SaveChanges();
        //    // This will delete the old horse "Mr. Ed"(method below) from the database and then add the new one, because the foreign key constraint doesn't allow a horse to exist in the database without a samurai
        //}

        //private static void AddNewHorseToDisconnectedSamuraiObject() {
        //    var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s => s.Id == 14);
        //    samurai.Horse = new Horse { Name = "Mr. Ed" };
        //    using (var newContext = new SamuraiContext()) {
        //        newContext.Attach(samurai);
        //        newContext.SaveChanges();
        //    }
        //}

        //private static void AddNewHorseToSamuraiObject() {
        //    var samurai = _context.Samurais.Find(15);
        //    samurai.Horse = new Horse { Name = "Black Beauty" };
        //    _context.SaveChanges();
        //}

        //private static void AddNewHorseToSamuraiUsingId() {
        //    var horse = new Horse { Name = "Scout", SamuraiId = 2 };
        //    _context.Add(horse); // We don't have a horse DbSet, so directly to context
        //    _context.SaveChanges();
        //}

        //private static void AddNewSamuraiWithHorse() {
        //    var samurai = new Samurai { Name = "Jina Ujichika" };
        //    samurai.Horse = new Horse { Name = "Silver" };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //// Many-to-many relationship
        //private static void GetSamuraiWithBattles() {
        //    var samuraiWithBattle = _context.Samurais
        //        .Include(s => s.SamuraiBattles)
        //        .ThenInclude(sb => sb.Battle)
        //        .FirstOrDefault(samurai => samurai.Id == 2);

        //    var samuraiWithBattlesCleaner = _context.Samurais.Where(s => s.Id == 2)
        //        .Select(s => new {
        //            Samurai = s,
        //            Battles = s.SamuraiBattles.Select(sb => sb.Battle)
        //        })
        //        .FirstOrDefault();
        //}

        //private static void RemoveJoinBetweenSamuraiAndBattleSimple() {
        //    // normally it is advised to have a true object, one that is queried from the database to use with the Remove method
        //    // but the SamuraiBattle is so simple that it is safe to just create it in memory
        //    var join = new SamuraiBattle { BattleId = 1, SamuraiId = 2 };
        //    _context.Remove(join);
        //    _context.SaveChanges();
        //}

        //private static void EnlistSamuraiIntoABattle() {
        //    //var battle = _context.Battles
        //    //    .Include(b => b.SamuraiBattles)
        //    //    .Single(b => b.Id == 3);
        //    var battle = _context.Battles.Find(3);
        //    battle.SamuraiBattles
        //        .Add(new SamuraiBattle { SamuraiId = 18 });
        //    _context.SaveChanges();
        //}

        //private static void JoinBattleAndSamurai() {
        //    // Samurai and Battle already exist and we have their IDs
        //    var sbJoin = new SamuraiBattle { SamuraiId = 1, BattleId = 3 };
        //    // We can't call _context.SamuraiBattle.Add etc, because we don't have (or want) a SamuraiBattle DbSet
        //    // But we can call Add, Attach, Update and Delete directly on the context
        //    _context.Add(sbJoin);
        //    _context.SaveChanges();
        //}

        //private static void ModifyingRelatedDataWhenNotTracked() {
        //    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 2);
        //    var quote = samurai.Quotes[0];
        //    quote.Text += " Did you hear that again?";
        //    using (var newContext = new SamuraiContext()) {
        //        //newContext.Quotes.Update(quote);
        //        // The above updates all quotes for this samurai, even those that have no update (it sends an update that doesn't change anything). Not good!
        //        // Instead of using the DbSet Add or similar method, you can use the DbContext Entry method. Gives you much more control
        //        // NOTE! Behaves very differently in EF Core 3.1 than in EF 6
        //        // In EF Core, Entry will focus specifically on the entry that you pass in and will ignore anything else that might be attached to it
        //        newContext.Entry(quote).State = EntityState.Modified;
        //        newContext.SaveChanges();
        //    }
        //}

        //private static void ModifyingRelatedDataWhenTracked() {
        //    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 2);
        //    // Modify:
        //    samurai.Quotes[0].Text = " Did you hear that?";
        //    // Delete:
        //    _context.Quotes.Remove(samurai.Quotes[2]);

        //    _context.SaveChanges();
        //}

        //private static void FilteringWithRelatedData() {
        //    var samurais = _context.Samurais
        //                            .Where(s => s.Quotes.Any(q => q.Text.Contains("happy")))
        //                            .ToList();
        //}

        //private static void LazyLoadQuotes() {
        //    // Lazy Loading is off by default, very easy to trigger, easy to get performance issues and other side effects if not used very carefully
        //    // To enable: 
        //    // * Every navigation property must be virtual
        //    // * Microsoft.EntityFramework.Proxies package
        //    // * ModelBuilder.UseLazyLoadingProxies()
        //    var samurai = _context.Samurais.FirstOrDefault(s => s.Name.Contains("Sampson"));
        //    var quoteCount = samurai.Quotes.Count();
        //}

        //private static void ExplicitLoadQuotes() {
        //    // Explicit Loading
        //    var samurai =
        //        _context.Samurais.FirstOrDefault(s => s.Name.Contains("Julie"));
        //    _context.Entry(samurai).Collection(s => s.Quotes).Load();
        //    _context.Entry(samurai).Reference(s => s.Horse).Load();
        //    // use of collection or reference is depending on the property you want to load. If it is a collection, use collection, and if it's a reference, use reference (duh!)
        //    // You can only load from a single object, so you wouldn't be able to use it for a list of samurais
        //    // It's then up to you to figure out if it's better to execute another LINQ query or to iterate through the list and load related data for each samurai
        //    // You can filter the related data with explicit loading. This is something you can't do with eager loading
        //}

        //private static void ProjectSamuraisWithQuotes() {
        //    //var somePropertiesWithQuotes = _context.Samurais
        //    //    .Select(s => new { s.Id, s.Name, s.Quotes })
        //    //    .ToList();
        //    //var somePropertiesWithQuotes = _context.Samurais
        //    //    .Select(s => new { s.Id, s.Name, s.Quotes.Count })
        //    //    .ToList();
        //    //var somePropertiesWithQuotes = _context.Samurais
        //    //    .Select(s => new { s.Id, s.Name, 
        //    //        HappyQuotes=s.Quotes.Where(q=>q.Text.Contains("happy")) })
        //    //        .ToList();
        //    var samuraisWithHappyQuotes = _context.Samurais
        //        .Select(s => new {
        //            Samurai = s,
        //            HappyQuotes = s.Quotes.Where(q => q.Text.Contains("happy"))
        //        })
        //        .ToList();
        //    var firstSamurai = samuraisWithHappyQuotes[0].Samurai.Name += " The Happiest";
        //}

        //private static void ProjectSomeProperties() {
        //    // Query projection
        //    var someProperties = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
        //    // the above will return an anonymous type, only known to this method
        //    // if I want to use it outside, I can do as below:
        //    var idsAndNames = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        //}
        //public struct IdAndName {
        //    public IdAndName(int id, string name) {
        //        Id = id;
        //        Name = name;
        //    }
        //    public int Id;
        //    public string Name;
        //}

        //private static void EagerLoadSamuraiWithQuotes() {
        //    // Eager loading
        //    var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
        //}

        //private static void AddQuoteToExistingSamuraiNotTracked_Easy(int samuraiId) {
        //    var quote = new Quote {
        //        Text = "Now that I've saved you, will you feed me dinner again?",
        //        SamuraiId = samuraiId
        //    };
        //    using (var newContext = new SamuraiContext()) {
        //        newContext.Quotes.Add(quote);
        //        newContext.SaveChanges();
        //    }
        //}

        //private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId) {
        //    var samurai = _context.Samurais.Find(samuraiId);
        //    samurai.Quotes.Add(new Quote {
        //        Text = "Now that I've saved you, will you feed me dinner?"
        //    });
        //    using (var newContext = new SamuraiContext()) {
        //        //newContext.Samurais.Update(samurai);
        //        // "Update" will update the samurai as well, even though nothing is changing for the samurai. Can be an issue if performance is critical. See  Attach below for a different way to do this
        //        newContext.Samurais.Attach(samurai);
        //        newContext.SaveChanges();
        //    }
        //}

        //private static void AddQuoteToExistingSamuraiWhileTracked() {
        //    var samurai = _context.Samurais.FirstOrDefault();
        //    samurai.Quotes.Add(new Quote {
        //        Text = "I bet you're happy that I've saved you!"
        //    });
        //    _context.SaveChanges();
        //}

        //private static void InsertNewSamuraiWithManyQuotes() {
        //    var samurai = new Samurai {
        //        Name = "Kyuzõ",
        //        Quotes = new List<Quote> {
        //            new Quote {Text = "Watch out for my sharp sword!"},
        //            new Quote {Text="I told you to watch out for the sharp sword! Oh well!"}
        //        }
        //    };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //private static void InsertNewSamuraiWithAQuote() {
        //    var samurai = new Samurai {
        //        Name = "Kambei Shimada",
        //        Quotes = new List<Quote> {
        //            new Quote {Text = "I've come to save you"}
        //        }
        //    };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //private static void QueryAndUpdateBattleDisconnected() {
        //    // Request the info using one context
        //    var battle = _context.Battles.AsNoTracking().FirstOrDefault();
        //    // Modify the retrieved data
        //    battle.EndDate = new DateTime(1560, 06, 30);
        //    // using a brand new context to push the changes to the database
        //    using (var newContextInstance = new SamuraiContext()) {
        //        newContextInstance.Battles.Update(battle);
        //        newContextInstance.SaveChanges();
        //    }
        //}

        //// The methods below demonstrate how things work with a connected client
        //// with a single DbContext, that can remember what it is doing
        //// For a disconnected client (e.g. web, where multiple users may access the database at the same time), each request starts its own DbContext and disposes it. And you have separate ones for retrieving and updating, and the updating one has no memory of what the retrieving context did. See the method above this for a simulated example

        //private static void InsertBattle() {
        //    _context.Battles.Add(new Battle {
        //        Name = "Battle of Okehazama",
        //        StartDate = new DateTime(1560, 05, 01),
        //        EndDate = new DateTime(1560, 06, 15)
        //    });
        //    _context.SaveChanges();
        //}

        //private static void RetrieveAndDeleteSamurai() {
        //    // For removing an object, it works best to first retrieve it into an object
        //    // Directly using the Remove method may sometimes work, but mostly not, and may have side effects, so retrieving it first is preferable
        //    // If you can't make it work, consider calling a stored procedure using EF Core raw SQL feature (later in course)

        //    var samurai = _context.Samurais.Find(13);
        //    _context.Samurais.Remove(samurai);
        //    _context.SaveChanges();
        //}

        //private static void RetrieveAndUpdateMultipleSamurais() {
        //    var samurais = _context.Samurais.Skip(1).Take(3).ToList();
        //    samurais.ForEach(s => s.Name += "San");
        //    _context.SaveChanges();
        //}

        //private static void RetrieveAndUpdateSamurai() {
        //    var samurai = _context.Samurais.FirstOrDefault();
        //    samurai.Name += "San";
        //    _context.SaveChanges();
        //}

        //private static void QueryFilters() {
        //    var name = "Sampson";
        //    //var samurais = _context.Samurais.FirstOrDefault(s => s.Name == name);
        //    //var samurai = _context.Samurais.Find(2);

        //    var last =
        //        _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);
        //    // LastOrDefault will only work if you first sort with the OrderBy method
        //    // otherwise it will throw a runtime exception

        //    //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();

        //    //var filter = "J%";
        //    //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter)).ToList();

        //}

        //private static void InsertMultipleSamurais() {
        //    var samurai = new Samurai { Name = "Sampson" };
        //    var samurai2 = new Samurai { Name = "Tasha" };
        //    var samurai3 = new Samurai { Name = "Number3" };
        //    var samurai4 = new Samurai { Name = "Number4" };
        //    _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
        //    _context.SaveChanges();
        //}

        //private static void InsertVariousTypes() {
        //    var samurai = new Samurai { Name = "Kikuchio" };
        //    var clan = new Clan { ClanName = "Imperial Clan" };
        //    _context.AddRange(samurai, clan);
        //    _context.SaveChanges();
        //}

        //private static void AddSamurai() {
        //    var samurai = new Samurai { Name = "Julie" };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //private static void GetSamuraisSimpler() {
        //    var query = _context.Samurais;
        //    //var samurais = query.ToList();
        //    foreach (var samurai in query) {
        //        Console.WriteLine(samurai.Name);
        //    }
        //    // The above way will keep the connection open as it is looping through the foreach loop. Can cause performance issues, esp with more complex queries
        //    // If first getting a result, e.g. with ToList(), you're done with the database before you perform the rest of your operations
        //}

        //private static void GetSamurais(string text) {
        //    var samurais = _context.Samurais.ToList();
        //    Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
        //    //foreach (var samurai in samurais) {
        //    //    Console.WriteLine(samurai.Name);
        //    //}
        //} 
        #endregion
    }
}
