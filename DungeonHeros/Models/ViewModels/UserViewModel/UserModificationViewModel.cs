using DungeonHeros.Models.CustomValidations;

namespace DungeonHeros.Models.ViewModels
{
    [UserValidation]
    public class UserModificationViewModel
    {
        public string Name { set; get; }
        
        public string ImagePath { set; get; }
    }
}