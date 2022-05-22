using System.Collections;
using System.Collections.Generic;

namespace DungeonHeros.Models.ViewModels.HallOfFame
{
    public class HallOfFameViewModel
    {
        public string DungeonName { set; get; }
        
        public IList<Hero> Heroes { set; get; }
        
        public int TeamId { set; get; }
    }
}