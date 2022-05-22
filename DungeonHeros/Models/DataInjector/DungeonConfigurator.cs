using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DungeonHeros.Models.DataInjector
{
    public interface IConfigureOnlyDungeon
    {
        void InjectDungeons();
    }
    
    public class DungeonConfigurator : IConfigureOnlyDungeon
    {
        private readonly DbContext _context;

        public DungeonConfigurator(DbContext context)
        {
            _context = context;
        }

        public void InjectDungeons()
        {

            var firstDungeon = _context.Monsters.Where(m => m.RaceId == 6).ToList();
            _context.Dungeons.Add(new Dungeon { Monsters = firstDungeon, ImagePath = "https://medias.spotern.com/spots/w640/90/90153-1532336916.jpg", DungeonName = "Etreinte de Servitude", TeamFighters = new List<Team>()});

            var secondDungeon = _context.Monsters.Where(m => m.RaceId == 7).ToList();
            _context.Dungeons.Add(new Dungeon { Monsters = secondDungeon, ImagePath = "https://medias.spotern.com/spots/w640/90/90153-1532336916.jpg", DungeonName = "Tour Galamadriabuyak", TeamFighters = new List<Team>()});

            var thirdDungeon = _context.Monsters.Where(m => m.RaceId == 7 || m.RaceId == 8).ToList();
             _context.Dungeons.Add(new Dungeon { Monsters = thirdDungeon, ImagePath = "https://medias.spotern.com/spots/w640/90/90153-1532336916.jpg", DungeonName = "Tour Clepsydre", TeamFighters = new List<Team>()});

            _context.SaveChangesAsync();
        }
    }
}