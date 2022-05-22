using System.Collections.Generic;

namespace DungeonHeros.Models
{
    public class Hero
    {
        public string HeroName { set; get; }
         
        public IEnumerable<Team>? Teams { get; set; }

        public int HeroId { set; get; }
        
        public int Strength { set; get; }

        public int Stamina { set; get; }
        
        public int ClassId { set; get; }
        public Class Class { set; get; }

        /**
         * On initialise par défaut la valeur à 1.
         */
        public double Level { set; get; } = 1.0;

        /**
         * Image par défaut pouvant être modifiée plus tard.
         */
        public string ImagePath { set; get; } = "https://cdn.pixabay.com/photo/2018/04/18/18/56/user-3331256_1280.png";

        public int RaceId { set; get; }
        public Race Race { set; get; }
        
        public User? User { set; get; }
        public IList<Message> Messages { set; get; }
    }
}