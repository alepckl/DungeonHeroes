using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonHeros.Models;
using DungeonHeros.Models.Factory.Bestiary;
using DungeonHeros.Models.ViewModels.BestiaryViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = DungeonHeros.Models.DbContext;

namespace DungeonHeros.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BestiaryController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly IBestiaryViewModel _viewModel;
        private readonly IBestiaryFactory _factory;

        public BestiaryController([FromServices] DbContext dbContext)
        {
            _dbContext = dbContext;
            _viewModel = new BestiaryViewModel();
            _factory = new BestiaryFactory();

        }
        // GET
        public IActionResult Bestiary()
        {
            var bestiaryViewModels = GetBestiaryInViewModel();
            return View(bestiaryViewModels);
        }

        private IList<DisplayBestiaryViewModel> GetBestiaryInViewModel()
        {
            var monsters = _dbContext.Monsters.ToList();
            IList<DisplayBestiaryViewModel> bestiaryViewModels =
                monsters.Select(monster => 
                    _viewModel.GetModelToDisplay(monster, GetRaceById(monster.RaceId))).ToList();
            return bestiaryViewModels;
        }
        
        public IActionResult AddMonster()
        {
            return View();
        }
        
        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddMonster(Monster monster)
        {
            if (!ModelState.IsValid) return RedirectToAction("AddMonster");
            
            _dbContext.Add(monster);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Bestiary");
        }

        private Race GetRaceById(int id) => _dbContext.Races.Single(r => r.RaceId == id);
        
        public IActionResult EditMonster(int id)
        {
            var toEdit = GetMonsterById(id);

            return View(toEdit);
        }
        
        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult EditMonster(Monster monster)
        {
            var monsterInDb = GetMonsterById(monster.MonsterId);
            if (!ModelState.IsValid) return View(monsterInDb);
            
            var toUpdate = _factory.UpdateMonster(monster, monsterInDb);
            _dbContext.Update(toUpdate);
            _dbContext.SaveChanges();
            return RedirectToAction("Bestiary");

        }

        public IActionResult DeleteMonster(int id)
        {
            var toDelete = GetMonsterById(id);
            _dbContext.Remove(toDelete);
            _dbContext.SaveChanges();

            return RedirectToAction("Bestiary");
        }

        private Monster GetMonsterById(int id) => _dbContext.Monsters.Include(m => m.Dungeons).Single(m => m.MonsterId == id);
        
    }
}