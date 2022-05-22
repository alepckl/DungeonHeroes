using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DungeonHeros.Models;
using DungeonHeros.Models.ViewModels.HallOfFame;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DbContext = DungeonHeros.Models.DbContext;

namespace DungeonHeros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, [FromServices] DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var dungeonTeams = _dbContext.DungeonTeams
                .Include(d => d.Dungeon).Include(t => t.Team).Where(team => team.HasWon == true).ToList();
            IList<HallOfFameViewModel> viewModels = 
                dungeonTeams.Select(dungeonTeam => new HallOfFameViewModel {DungeonName = dungeonTeam.Dungeon.DungeonName, Heroes = GetHeroesById(dungeonTeam.TeamId), TeamId = dungeonTeam.TeamId}).ToList();
            return View(viewModels);
        }

        private IList<Hero> GetHeroesById(int id) =>
            _dbContext.Teams.Where(team => team.TeamId == id).SelectMany(e => e.Heroes).ToList(); 
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}