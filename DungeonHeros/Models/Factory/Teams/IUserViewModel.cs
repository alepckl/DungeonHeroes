using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DungeonHeros.Models.ViewModels;

namespace DungeonHeros.Models.Factory
{
    public interface IUserViewModel
    {
        public UserViewModel CreateViewModel(Hero getHero, Race race, Class c);
    }

    public class FactoryViewModel : IUserViewModel
    {

        public UserViewModel CreateViewModel(Hero hero, Race race, Class c)
        {
            var raceName = race.Name;
            var className = c.ClassName;
            return new UserViewModel(
                hero.HeroId, raceName, hero.ImagePath, hero.HeroName, hero.Strength, hero.Stamina, Convert.ToInt32(hero.Level), className
                );
        }
    }
}