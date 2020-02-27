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
            QueryFilters();
        }

        private static void QueryFilters() {
            //var name = "Sampson";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList();

            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();

            var filter = "J%";
            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter)).ToList();

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
