using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DungeonHeros.Models.Factory
{
    public interface ITeamFactory
    {
        Team CreateTeam(IList<Hero> heroes, Models.User currentUser);
        
        Team UpdateTeam(Team toApply, IList<Hero> newHeroes);
    }

    public class TeamFactory : ITeamFactory
    {
        public Team CreateTeam(IList<Hero> heroes, Models.User currentUser) => 
            new() {Heroes = heroes, FightedDungeons = new List<Dungeon>(), Founder = currentUser};

        public Team UpdateTeam(Team toApply, IList<Hero> newHeroes)
        {
            // Supprime la liste et on y ajoute les nouveaux héros.
            toApply.Heroes.Clear();
            toApply.Heroes = newHeroes;
            
            return toApply;

        }
    }
}