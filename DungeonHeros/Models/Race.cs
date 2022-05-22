using System.Collections;
using System.Collections.Generic;

namespace DungeonHeros.Models
{
    public class Race
    {
        public int RaceId { set; get; }
        
        public int IsForUser { set; get; } = 0;
        
        public string Name { set; get; }
        
        public IEnumerable<Hero> Heroes { set; get; }
    }
}