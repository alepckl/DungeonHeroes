using DungeonHeros.Models.CustomValidations;

namespace DungeonHeros.Models.ViewModels
{
    [TeamValidation]
    public class TeamViewModel
    {
        public string[] Players { set; get; }
        
        // Utilisé pour l'update.
        public int TeamId { set; get; }
    }
}