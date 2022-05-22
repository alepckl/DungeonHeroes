using System.Collections;
using System.Collections.Generic;

namespace DungeonHeros.Models.ViewModels
{
    public class EditTeamViewModel
    {
        public IList<UserViewModel> AlreadyInTeam { set; get; }
        
        public IList<UserViewModel> NotInTeam { set; get; }
    }
}