using System.Collections.Generic;

namespace DungeonHeros.Models.ViewModels.DungeonViewModel
{
    public class DungeonDisplayViewModel
    {
        public int DungeonId { set; get; }

        public List<Monster> Monsters { set; get; }
    }
}