using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DungeonHeros.Models.ViewModels;

namespace DungeonHeros.Models.CustomValidations
{
    public class TeamValidationAttribute : ValidationAttribute
    {
        private DbContext _service;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Récupère le DB Context.
            _service = (DbContext) validationContext.GetService(typeof(DbContext));
            
            var teamVm = (TeamViewModel) validationContext.ObjectInstance;
            var length = teamVm.Players.Length;
            
            // Vérifie la taille de la collection.
            if (length is < 2 or > 4) return new ValidationResult(GetLengthMessage());
            
            // Vérifie si une classe ne se répète pas 2x.
            var heroes = GetAllHeroesById(teamVm.Players);
            return IsClassRepeatMoreThenTwo(heroes) ? 
                new ValidationResult(GetClassesMessage()) : ValidationResult.Success;
        }
        
        /**
         * Récupère un héro sur base de son ID.
         */
        private Hero GetHeroesById(string id) => _service.Heroes.Single(h => h.HeroId == int.Parse(id));

        /**
         * Récupère une liste de héro sur base de leurs ID.
         */
        private IList<Hero> GetAllHeroesById(IEnumerable<string> players) => players.Select(GetHeroesById).ToList();

        /**
         * Vérifie si une classe est repetée plus de 2 fois dans nos nouveaux utilisateurs.
         */
        private static bool IsClassRepeatMoreThenTwo(IList<Hero> heroes) => 
            heroes.Any(hero => heroes.Where(current => hero.ClassId == current.ClassId).ToList().Count > 2);

        
        private static string GetLengthMessage() => "Your team cannot have less than 2 and more than 4 members";
        private static string GetClassesMessage() => "Your team cannot contain more than 2 similar classes for your heroes.";

    }
}