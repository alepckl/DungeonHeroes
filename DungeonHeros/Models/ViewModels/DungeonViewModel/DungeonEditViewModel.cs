using System.Collections;
using System.Collections.Generic;

namespace DungeonHeros.Models.ViewModels.DungeonViewModel
{
    public class DungeonEditViewModel
    {
        public int DungeonId { set; get; }
        
        public string ImagePath { set; get; }
        
        public string DungeonName { set; get; }
    
        public IList<Monster> AlreadyInTeam { set; get; }
        
        public IList<Monster> EachOther { set; get; }
    }
}