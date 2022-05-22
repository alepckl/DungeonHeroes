using System.ComponentModel.DataAnnotations;
using DungeonHeros.Models.ViewModels.DungeonViewModel;

namespace DungeonHeros.Models.CustomValidations
{
    public class DungeonValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dungeonVM = (DungeonViewModel) validationContext.ObjectInstance;
            var length = dungeonVM.MonsterId.Length;

            // Vérifie la taille de la collection.
            if (length <= 0) return new ValidationResult(GetErrorLength());
            
            // Vérifie la taille du nom.
            return dungeonVM.DungeonName.Length == 0 ? 
                new ValidationResult(GetErrorName()) : ValidationResult.Success;
        }

        private static string GetErrorLength() => "You can't create team without monsters.";
        private static string GetErrorName() => "Name can't be empty. Please retry with another.";
    }
}