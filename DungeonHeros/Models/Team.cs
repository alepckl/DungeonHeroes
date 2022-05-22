using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DungeonHeros.Models.ManyToMany;

namespace DungeonHeros.Models
{
    public class Team
    {
        public int TeamId { set; get; }
        
        public IList<Hero> Heroes { set; get; }

        public User Founder { set; get; }        
        
        public IEnumerable<Dungeon> FightedDungeons { set; get; }


        public int CalculateStrength() => 
            Heroes.Sum(hero => hero.Strength + Convert.ToInt32(hero.Level));
        
        public int CalculateStamina() => 
            Heroes.Sum(hero => hero.Stamina + Convert.ToInt32(hero.Level));

        public void UpdateLevel(Dungeon dungeon)
        {
            var toAdd = (double) dungeon.CalculateStrength() / CalculateStrength();

            foreach (var hero in Heroes)
            {
                var newValue = hero.Level += toAdd;
                var round = Math.Round(newValue, 2);
                hero.Level = round;
            }
        }
    }
}