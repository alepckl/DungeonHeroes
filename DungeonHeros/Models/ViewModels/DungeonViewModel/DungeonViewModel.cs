using DungeonHeros.Models.CustomValidations;

namespace DungeonHeros.Models.ViewModels.DungeonViewModel
{
    [DungeonValidation]
    public class DungeonViewModel
    {
        public int DungeonId { set; get; }
        
        public string DungeonName { set; get; }
        
        public string ImagePath { set; get; }
        
        public string[] MonsterId { set; get; }
    }
}