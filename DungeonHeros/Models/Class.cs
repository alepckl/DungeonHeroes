using System.Collections.Generic;

namespace DungeonHeros.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        
        public IEnumerable<Hero> Heroes { set; get; }
    }
}