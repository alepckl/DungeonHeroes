using System.ComponentModel.DataAnnotations;

namespace DungeonHeros.Models.CustomValidations
{
    public class MonsterValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var monster = (Monster) validationContext.ObjectInstance;
            if (monster.MonsterName.Length == 0 || monster.RaceId > 8 || string.IsNullOrEmpty(monster.ImagePath))
                return new ValidationResult("Check your answers and correct them");
            
            
            return ValidationResult.Success;          //ValidationResult.Success;
        }
    }
}