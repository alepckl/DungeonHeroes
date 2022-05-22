using System.Collections.Generic;
using System.Linq;
using DungeonHeros.Models.ViewModels.DungeonViewModel;

namespace DungeonHeros.Models.Factory.Dungeons
{
    public interface IDungeonViewModel
    {
        DungeonEditViewModel CreateEditModel(Dungeon dungeon, IList<Monster> allMonsters);
    }

    public class FactoryDungeonVm : IDungeonViewModel
    {
        public DungeonEditViewModel CreateEditModel(Dungeon dungeon, IList<Monster> allMonsters)
        {
            IList<Monster> notInTeam = 
                allMonsters.Where(currentMonster => !dungeon.Monsters.Contains(currentMonster)).ToList();

            return new DungeonEditViewModel
                {DungeonId = dungeon.DungeonId, ImagePath = dungeon.ImagePath,DungeonName = dungeon.DungeonName, AlreadyInTeam = dungeon.Monsters, EachOther = notInTeam};
        }
    }
}