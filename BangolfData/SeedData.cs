using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BangolfModels;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace BangolfData
{
    public class SeedData
    {
        private static Faker faker = null!;
        public static async Task InitAsync(BangolfWebContext db) 
        {
            if (await db.Player.AnyAsync()) return;
            
            faker = new Faker("sv");

            var players = GeneratePlayers(50);
            await db.AddRangeAsync(players);

            //Arena
            var arenas = GenerateArenas(10);
            await db.AddRangeAsync(arenas);

            //Competitions
            var competitions = GenerateCompetitions(players,arenas);
            await db.AddRangeAsync(competitions);


            await db.SaveChangesAsync();
        }

        private static IEnumerable<Competition> GenerateCompetitions(IEnumerable<Player> players, IEnumerable<Arena> arenas)
        {
            Random random = new Random();
            var competitions=new List<Competition>();
            foreach (var player in players)
            {
                foreach (var arena in arenas)
                {
                    if (random.Next(0, 3) == 0) 
                    {
                        var competition = new Competition
                        {
                            Arena = arena,
                            Player = player,
                            Score = random.Next(27, 43)

                        };
                        competitions.Add(competition);
                    }
                    
                }
            }
            return competitions;    
        }

        private static IEnumerable<Arena> GenerateArenas(int numberOfArenas)
        {
          var arenas  = new List<Arena>();
            Random random = new Random();
            for (int i = 0; i < numberOfArenas; i++)
            {
            var name = faker.Address.City();
                var par = random.Next(25, 32);
                arenas.Add(new Arena(name, par));

            }
            return arenas;
        }

        private static IEnumerable<Player> GeneratePlayers(int numberOfPlayers) 
        {
        var players =new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++) 
            {
                var name =faker.Name.FirstName();
                var club = faker.Address.City();
                var player = new Player(name, club);
                players.Add(player);

                   
            }
            return players;
        }
    }
}
