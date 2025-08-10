using System;
using MatchupMashup.Models;

namespace MatchupMashup
{
    class Program
    {
        static void Main(string[] args)
        {
            Team broncos = new Team("Denver Broncos", "DEN", "AFC", "West", 10, 7);
            Team bengals = new Team("Cincinatti Bengals", "CIN", "AFC", "North", 9, 8);

            // Display team info
            Console.WriteLine($"Broncos Win Rate: {broncos.WinRate:P1}");
            Console.WriteLine($"Benglas Win Rate: {bengals.WinRate:P1}");
            

            // Wait for user before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
