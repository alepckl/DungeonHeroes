using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DungeonHeros.Models.Factory
{
    public interface IDungeonFactory
    {
        Dungeon CreateDungeon(string name, string path, IList<Monster> monsters);

        Dungeon UpdateDungeon(string name, string path, IList<Monster> monsters, Dungeon toChange);
        bool AttackDungeon(Team team, Dungeon dungeon);
    }

    public class DungeonFactory : IDungeonFactory
    {
        public Dungeon CreateDungeon(string name, string path, IList<Monster> monsters)
        {
            string imagePath = string.IsNullOrEmpty(path) ? "https://medias.spotern.com/spots/w640/90/90153-1532336916.jpg" : path;
            return new Dungeon {DungeonName = name, Monsters = monsters, ImagePath = imagePath, DungeonLevel = CalculateStrength(monsters), TeamFighters = new List<Team>()};
        }

        public Dungeon UpdateDungeon(string name, string path, IList<Monster> monsters, Dungeon toChange)
        {
            toChange.Monsters.Clear();
            toChange.Monsters = monsters;
            string imagePath = string.IsNullOrEmpty(path) ? "https://medias.spotern.com/spots/w640/90/90153-1532336916.jpg" : path;
            toChange.ImagePath = imagePath;
            toChange.DungeonName = name;
            toChange.DungeonLevel = toChange.CalculateStrength();
            return toChange;
        }

        public bool AttackDungeon(Team team, Dungeon dungeon)
        {
            var isWin = dungeon.SubmitAttack(team);
            if(isWin) team.UpdateLevel(dungeon);
            return isWin;
        }

        private static int CalculateStrength(IEnumerable<Monster> monsters) => 
            monsters.Sum(monster => monster.Strength);
        
        
    }
}