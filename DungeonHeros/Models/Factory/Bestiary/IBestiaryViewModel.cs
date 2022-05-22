using System.Collections;
using System.Collections.Generic;
using DungeonHeros.Models.ViewModels.BestiaryViewModel;

namespace DungeonHeros.Models.Factory.Bestiary
{
    public interface IBestiaryViewModel
    {
        DisplayBestiaryViewModel GetModelToDisplay(Monster monster, Race race);
    }

    public class BestiaryViewModel : IBestiaryViewModel
    {
        public DisplayBestiaryViewModel GetModelToDisplay(Monster monster, Race race)
        {
            return new DisplayBestiaryViewModel
            {
                Name = monster.MonsterName, Stamina = monster.Stamina, Strength = monster.Strength,
                RaceName = race.Name, ImagePath = monster.ImagePath, MonsterId = monster.MonsterId
            };
        }
    }
}