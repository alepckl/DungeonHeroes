using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonHeros.Models;
using DungeonHeros.Models.Factory;
using DungeonHeros.Models.Factory.Dungeons;
using DungeonHeros.Models.ManyToMany;
using DungeonHeros.Models.ViewModels.DungeonViewModel;
using DungeonHeros.Models.ViewModels.ResultViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = DungeonHeros.Models.DbContext;

namespace DungeonHeros.Controllers
{
    [Authorize]
    public class DungeonsController : Controller
    {
        private readonly DbContext _context;
        private readonly IDungeonFactory _factory;
        private readonly IDungeonViewModel _viewModel;
        private readonly UserManager<User> _manager;

        public DungeonsController([FromServices] DbContext context, UserManager<User> manager)
        {
            _context = context;
            _factory = new DungeonFactory();
            _viewModel = new FactoryDungeonVm();
            _manager = manager;
        }

        public IActionResult Dungeons(int id)
        {
            if (id == 0)
            {
                ViewData["TeamId"] = null;
            }
            else
            {
                ViewData["TeamId"] = id;   
            }
            var allDungeons = _context.Dungeons.Include(m => m.Monsters).ToList();

            return View(allDungeons);
        }

        [HttpPost]
        public async Task<IActionResult> Dungeons(int id, string name)
        {
            if (string.IsNullOrEmpty(name)) return RedirectToAction("Dungeons");
            var dj = GetDungeonByName(name);
            if (id == 0)
            {
                ViewData["TeamId"] = null;
            }
            else
            {
                ViewData["TeamId"] = id;   
            }
            return View(dj);
        }
        
        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> FightDungeons(int teamId, int dungeonId)
        {
            var dungeon = GetDungeonById(dungeonId);
            var team = GetTeamById(teamId);
            if (team.Founder.Id != GetCurrentUser().Id) return RedirectToAction("Dungeons");

            var hasWon = _factory.AttackDungeon(team, dungeon);
            // Mettre à jour la table DungeonTeam.
            if (hasWon)
            {
                _context.Update(team);
                _context.Add(new DungeonTeam { Dungeon = dungeon, Team = team, DungeonId = dungeon.DungeonId, TeamId = team.TeamId, HasWon = true});
                await _context.SaveChangesAsync();
                return RedirectToAction("ResultDungeon", new {result = true});
            }

            _context.Add(new DungeonTeam { Dungeon = dungeon, Team = team, DungeonId = dungeon.DungeonId, TeamId = team.TeamId, HasWon = false});
            return RedirectToAction("ResultDungeon", new {result = false});
        }
        
        public IActionResult ResultDungeon(bool result)
        {
            return View(result ? 
                new ResultViewModel{Title = "Victory", Corpse = "You have defeated the dungeon! The experience of the heroes who participated in the dungeon has increased."} 
                : new ResultViewModel{Title = "You loose", Corpse = "You have lost your battle. Your experience has not changed."});
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDungeon(int id)
        {
            var toDelete = GetDungeonById(id);
            _context.Remove(toDelete);
            _context.SaveChangesAsync();
            return RedirectToAction("Dungeons");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDungeon()
        {
            return View(_context.Monsters.ToList());
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateDungeon(DungeonViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(_context.Monsters.ToList());

            IList<Monster> allMonsters =
                viewModel.MonsterId.Select(monster => GetMonsterById(int.Parse(monster))).ToList();
            var newDungeon = _factory.CreateDungeon(viewModel.DungeonName, viewModel.ImagePath, allMonsters);
            _context.Add(newDungeon);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dungeons");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditDungeon(int id)
        {
            var model = _viewModel.CreateEditModel(GetDungeonById(id), _context.Monsters.ToList());
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditDungeon(DungeonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dungeon = GetDungeonById(vm.DungeonId);
                var newDungeon = _factory.UpdateDungeon(vm.DungeonName, vm.ImagePath, GetMonsters(vm.MonsterId), dungeon);

                // Update les valeurs en db.
                _context.Update(newDungeon);
                await _context.SaveChangesAsync();

                // Redirection
                return RedirectToAction("Dungeons");
            }

            // Cas d'erreur
            var model = _viewModel.CreateEditModel(GetDungeonById(vm.DungeonId), _context.Monsters.ToList());
            return View(model);
        }

        private Dungeon GetDungeonById(int id) =>
            _context.Dungeons.Include(m => m.Monsters).Single(d => d.DungeonId == id);

        private Monster GetMonsterById(int id) => _context.Monsters.Single(m => m.MonsterId == id);

        private IList<Monster> GetMonsters(IEnumerable<string> monsters) =>
            monsters.Select(monster => GetMonsterById(int.Parse(monster))).ToList();

        public async Task AttackDungeon()
        {
            RedirectToAction("Dungeons");
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AttackDungeon(int teamId, int dungeonId)
        {
            var dungeon = GetDungeonById(dungeonId);
            var team = GetTeamById(teamId);
            if (team.Founder.Id != GetCurrentUser().Id) return RedirectToAction("Dungeons");

            var hasWon = _factory.AttackDungeon(team, dungeon);
            // Mettre à jour la table DungeonTeam.
            
            // Rediriger.
            
            return RedirectToAction("Dungeons");
        }
        
        private User GetCurrentUser()
        {
            var t = _manager.GetUserId(HttpContext.User);
            return GetUserById(t);
        }

        [Produces("application/json")]
        public async Task<IActionResult> SearchDungeon()
        {
            string term = HttpContext.Request.Query["term"].ToString();
            var list = await _context.Dungeons.Where(d => d.DungeonName.Contains(term)).Select(d => d.DungeonName).ToListAsync();
            return Ok(list);
        }

        private List<Dungeon> GetDungeonByName(string name) =>
            _context.Dungeons.Include(h => h.Monsters).Where(d => d.DungeonName.Contains(name)).ToList();
        
        private User GetUserById(string id) => _context.Users.Single(u => u.Id == id);

        private Team GetTeamById(int id) => _context.Teams.Include(f => f.Founder).Include(h => h.Heroes).Single(t => t.TeamId == id);
    }
}