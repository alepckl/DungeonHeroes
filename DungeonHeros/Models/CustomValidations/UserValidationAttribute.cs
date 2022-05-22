using System.ComponentModel.DataAnnotations;
using DungeonHeros.Models.ViewModels;

namespace DungeonHeros.Models.CustomValidations
{
    public class UserValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var viewModel = (UserModificationViewModel) validationContext.ObjectInstance;
            if (viewModel.Name.Length == 0 || viewModel.ImagePath.Length == 0)
                return new ValidationResult("Values must not be empty.");
            
            return ValidationResult.Success;

        }
    }
}