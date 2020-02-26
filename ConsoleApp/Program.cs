using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp {
    internal class Program {

        // NOTE: This is just for demo, very simple! 
        // NOT best practise, not recommended for use in real software!

        private static SamuraiContext context = new SamuraiContext();
        static void Main(string[] args) {
            context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void AddSamurai() {
            var samurai = new Samurai { Name = "Sampson" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text) {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais) {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
