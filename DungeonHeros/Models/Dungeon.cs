using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DungeonHeros.Models
{
    public class Dungeon
    {
        private Random _rdm = new ();
        public int DungeonId { set; get; }
        public string DungeonName { set; get; }
        public string ImagePath { set; get; }
        public int DungeonLevel { set; get; }
        public IList<Monster> Monsters { set; get; }
        public IEnumerable<Team> TeamFighters { set; get; }

        public int CalculateStrength() => 
            Monsters.Sum(monster => monster.Strength);
        
        public int CalculateStamina() => 
            Monsters.Sum(monster => monster.Stamina);

        private double CalculateValue(int value)
        {
            var toMultiply = Math.Round(_rdm.NextDouble() * (3.0 - 0.0) + 0.0, 2);
            return value * toMultiply;
        }

        public bool SubmitAttack(Team team)
        {
            var isHeroAlive = CalculateValue(team.CalculateStamina()) - CalculateValue(CalculateStrength()) > 0;
            var isMonsterDown = CalculateValue(CalculateStamina()) - CalculateValue(team.CalculateStrength()) < 0;
            return isHeroAlive && isMonsterDown;
        }
    }
}