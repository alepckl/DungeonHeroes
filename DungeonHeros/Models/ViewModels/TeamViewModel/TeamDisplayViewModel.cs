using System.Collections;
using System.Collections.Generic;

namespace DungeonHeros.Models.ViewModels
{
    public class TeamDisplayViewModel
    {
        public int TeamId { set; get; }
        public IList<UserViewModel> allHeroes { set; get; }
    }
}