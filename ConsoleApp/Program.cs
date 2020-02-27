using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp {
    internal class Program {

        // NOTE: This is just for demo, very simple! 
        // NOT best practise, not recommended for use in real software!

        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args) {
            //_context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //InsertMultipleSamurais();
            //InsertVariousTypes();
            //AddSamurai();
            //GetSamuraisSimpler("After Add:");
            //Console.WriteLine("Press any key");
            //Console.ReadKey();
            //QueryFilters();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //RetrieveAndDeleteSamurai();
            //InsertBattle();
            QueryAndUpdateBattleDisconnected();
        }

        private static void QueryAndUpdateBattleDisconnected() {
            // Request the info using one context
            var battle = _context.Battles.AsNoTracking().FirstOrDefault();
            // Modify the retrieved data
            battle.EndDate = new DateTime(1560, 06, 30);
            // using a brand new context to push the changes to the database
            using (var newContextInstance = new SamuraiContext()) {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }
                     
        // The methods below demonstrate how things work with a connected client
        // with a single DbContext, that can remember what it is doing
        // For a disconnected client (e.g. web, where multiple users may access the database at the same time), each request starts its own DbContext and disposes it. And you have separate ones for retrieving and updating, and the updating one has no memory of what the retrieving context did. See the method above this for a simulated example

        private static void InsertBattle() {
            _context.Battles.Add(new Battle {
                Name="Battle of Okehazama",
                StartDate=new DateTime(1560, 05, 01),
                EndDate=new DateTime(1560, 06, 15)
            });
            _context.SaveChanges();
        }
                      
        private static void RetrieveAndDeleteSamurai() {
            // For removing an object, it works best to first retrieve it into an object
            // Directly using the Remove method may sometimes work, but mostly not, and may have side effects, so retrieving it first is preferable
            // If you can't make it work, consider calling a stored procedure using EF Core raw SQL feature (later in course)
            
            var samurai = _context.Samurais.Find(13);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais() {
            var samurais = _context.Samurais.Skip(1).Take(3).ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateSamurai() {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        private static void QueryFilters() {
            var name = "Sampson";
            //var samurais = _context.Samurais.FirstOrDefault(s => s.Name == name);
            //var samurai = _context.Samurais.Find(2);

            var last =
                _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);
            // LastOrDefault will only work if you first sort with the OrderBy method
            // otherwise it will throw a runtime exception

            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();

            //var filter = "J%";
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter)).ToList();

        }

        private static void InsertMultipleSamurais() {
            var samurai = new Samurai { Name = "Sampson" };
            var samurai2 = new Samurai { Name = "Tasha" };
            var samurai3 = new Samurai { Name = "Number3" };
            var samurai4 = new Samurai { Name = "Number4" };
            _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            _context.SaveChanges();
        }

        private static void InsertVariousTypes() {
            var samurai = new Samurai { Name = "Kikuchio" };
            var clan = new Clan { ClanName = "Imperial Clan" };
            _context.AddRange(samurai, clan);
            _context.SaveChanges();
        }

        private static void AddSamurai() {
            var samurai = new Samurai { Name = "Julie" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamuraisSimpler() {
            var query = _context.Samurais;
            //var samurais = query.ToList();
            foreach (var samurai in query) {
                Console.WriteLine(samurai.Name);
            }
            // The above way will keep the connection open as it is looping through the foreach loop. Can cause performance issues, esp with more complex queries
            // If first getting a result, e.g. with ToList(), you're done with the database before you perform the rest of your operations
        }

        private static void GetSamurais(string text) {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            //foreach (var samurai in samurais) {
            //    Console.WriteLine(samurai.Name);
            //}
        }
    }
}
