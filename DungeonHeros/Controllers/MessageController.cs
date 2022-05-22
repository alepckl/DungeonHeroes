using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonHeros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = DungeonHeros.Models.DbContext;

namespace DungeonHeros.Controllers
{
    public class MessageController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<User> _manager;
        public MessageController([FromServices] DbContext dbContext, UserManager<User> manager)
        {
            _dbContext = dbContext;
            _manager = manager;
        }
        
        private User GetCurrentUser()
        {
            var t = _manager.GetUserId(HttpContext.User);
            return GetUserById(t);
        }
        
        private User GetUserById(string id) => 
            _dbContext.Users.Include(h => h.Hero).Single(u => u.Id == id);

        private Hero GetMessageById(int id) =>
            _dbContext.Heroes.Include(h => h.Messages).Single(m => m.HeroId == id);

        [Authorize]
        public IActionResult Messages()
        {
            var id = GetCurrentUser().Hero.HeroId;
            var messages = GetMessageById(id);
            return View(messages);
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult SendMessage(int id)
        {
            ViewData["TeamId"] = id;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(int teamId, string title, string message)
        {
            var currentTeam = GetTeamById(teamId);

            _dbContext.Add(new Message {MessageContent = message, MessageTitle = title, Heroes = currentTeam.Heroes});
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private Team GetTeamById(int id) => _dbContext.Teams.Include(h => h.Heroes).Single(t => t.TeamId == id);
    }
}