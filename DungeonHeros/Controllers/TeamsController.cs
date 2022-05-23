using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonHeros.Models;
using DungeonHeros.Models.Factory;
using DungeonHeros.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DungeonHeros.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly DungeonHeros.Models.DbContext _dbContext;
        private readonly UserManager<User> _manager;
        private readonly IUserViewModel _teamFactory;
        private readonly ITeamFactory _tt;
        public TeamsController(DungeonHeros.Models.DbContext dbContext, UserManager<User> manager)
        {
            _dbContext = dbContext;
            _manager = manager;
            _teamFactory = new FactoryViewModel();
            _tt = new TeamFactory();
        }
        
        // GET
        [Authorize]
        public IActionResult Teams()
        {
            var user = GetCurrentUser();
            var teams = GetAllTeamForUser(user);
            return View(teams);
        }
        
        [Authorize]
        public IActionResult Delete(string id)
        {
            var teamToDelete = GetTeamById(int.Parse(id));
            _dbContext.Remove(teamToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Teams");
        }

        [Authorize]
        public IActionResult TeamModification(int id)
        {
            var toDisplay = ToDisplayForModifications(id);
            return View(toDisplay);
        }

        /**
         * Détermine les collections à afficher pour notre utilisateur.
         */
        private EditTeamViewModel ToDisplayForModifications(int id)
        {
            var heroId = GetHeroesById(GetCurrentUser().HeroForeignKey.ToString()).HeroId;
            ViewData["HeroId"] = heroId;
            if (id == null) RedirectToAction("Teams");
            var toDisplay = GetMyTeam(id, heroId);
            ViewData["ToModif"] = id;
            return toDisplay;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> TeamModification(TeamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // On récupère la team et nos nouveaux héros sous forme de liste.
                var currentTeam = GetTeamById(viewModel.TeamId);
                var heroes = GetAllHeroesById(viewModel.Players);

                // On update notre team.
                var updateTeam = _tt.UpdateTeam(currentTeam, heroes);

                // On applique et sauvegarde en DB.
                _dbContext.Teams.Update(updateTeam);
                _dbContext.SaveChanges();   
                return RedirectToAction("Teams");
            }
            var toDisplay = ToDisplayForModifications(viewModel.TeamId);
            return View(toDisplay);
        }

        
        public IActionResult CreateTeam()
        {
            var vm = ViewToDisplay();
            return View(vm);
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateTeam(TeamViewModel teamViewModel)
        {
            if (ModelState.IsValid)
            {
                // Récupère la liste des héros
                var heroes = GetAllHeroesById(teamViewModel.Players);

                // Récupère l'utilisateur actuellement connecté
                var currentUser = GetCurrentUser();
                var newTeam = _tt.CreateTeam(heroes, currentUser);
                
                // Ajoute et sauvegarde.
                _dbContext.Teams.Add(newTeam);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Teams");   
            }

            var vm = ViewToDisplay();
            return View(vm);
        }

        private IList<UserViewModel>? ViewToDisplay()
        {
            var u = GetCurrentUser();
            ViewData["HeroId"] = u.HeroForeignKey;
            var vm = FormatUsersToModel(u.HeroForeignKey);
            return vm;
        }

        /**
         * Retourne tous les héros d'une équipe crée (ou modifiée) sur base de leurs différents iD.
         * Ne retourne rien s'ils étaient nulls.
         */
        private IList<Hero> GetAllHeroesById(IEnumerable<string> players) => players.Select(GetHeroesById).ToList();
        

        private Hero GetHeroesById(string id) => _dbContext.Heroes.Single(h => h.HeroId == int.Parse(id));


        /**
         * Retourne toute les équipe d'un utilisateur donné.
         */
        private IList<TeamDisplayViewModel> GetAllTeamForUser(User user)
        {
            var teams = _dbContext.Teams.Where(t => t.Founder.Id == user.Id).ToList();

            IList<TeamDisplayViewModel> allTeams = new List<TeamDisplayViewModel>();

            foreach (var team in teams)
            {
                var heroes = _dbContext.Teams.Where(t => t.TeamId == team.TeamId).SelectMany(t => t.Heroes).ToList();
                    List<UserViewModel> current = heroes.Select(hero => _teamFactory.CreateViewModel(hero, GetRaceById(hero.RaceId), GetClassById(hero.ClassId))).ToList();
                    allTeams.Add(new TeamDisplayViewModel{ TeamId = team.TeamId, allHeroes = current});
            }
            return allTeams;
        }

        /**
         * Récupère les équipes d'un utilisateur connecté.
         */
        private EditTeamViewModel GetMyTeam(int teamId, int founderHeroId)
        {
            // On prend tous les héros de notre collection.
            var allHeroes = _dbContext.Teams
                .Where(t => t.TeamId == teamId)
                .SelectMany(t => t.Heroes)
                .Where(h => h.HeroId != founderHeroId)
                .ToList();
            

            IList<Hero> heroesCanBeAdded = new List<Hero>();
            foreach (var hero in _dbContext.Heroes)
            {
                var isEquals = false;
                foreach (var heroIn in allHeroes.Where(heroIn => hero.HeroId == heroIn.HeroId))
                {
                    isEquals = true;
                }
                if (!isEquals && hero.HeroId != founderHeroId) heroesCanBeAdded.Add(hero);
            }

            return new EditTeamViewModel {AlreadyInTeam = HeroesToModel(allHeroes), NotInTeam = HeroesToModel(heroesCanBeAdded)};
        }

        /**
         * Formate les différents Héros au format pour l'affichage.
         */
        private IList<UserViewModel> HeroesToModel(IEnumerable<Hero> heroes) => heroes.Select(t => _teamFactory.CreateViewModel(t,
                GetRaceById(t.RaceId), GetClassById(t.ClassId))).ToList();

        /**
         * Formateles héros qui ne sont pas celui fourni en paramètre.
         */
        private IList<UserViewModel> FormatUsersToModel(int id)
        {
            var heroesList = _dbContext.Heroes.Where(current => current.HeroId != id).ToList();
            return HeroesToModel(heroesList);
        }

        /**
         * Retourne l'utilisateur connecté.
         */
        private User GetCurrentUser()
        {
            var t = _manager.GetUserId(HttpContext.User);
            return GetUserById(t);

        }

        /**
         * Retourne l'utilisateur sur base de son ID.
         */
        private User GetUserById(string id) => _dbContext.Users.Include(h => h.Hero).Single(u => u.Id == id);
        

        /**
         * Retourne une race sur base de son ID.
         */
        private Race GetRaceById(int id) => _dbContext.Races.Single(race => race.RaceId == id);
        
        /**
         * Retourne une classe sur base de son ID.
         */
        private Class GetClassById(int id) => _dbContext.Classes.Single(cl => cl.ClassId == id);

        private Team GetTeamById(int id) => _dbContext.Teams.Include(t => t.Heroes).Single(t => t.TeamId == id);

    }
}