using System.Linq;
using System.Threading.Tasks;
using DungeonHeros.Models;
using DungeonHeros.Models.Factory.User;
using DungeonHeros.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = DungeonHeros.Models.DbContext;

namespace DungeonHeros.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<User> _manager;
        private readonly IUserFactory _factory;

        public UserController([FromServices] DbContext dbContext, UserManager<User> manager)
        {
            _dbContext = dbContext;
            _manager = manager;
            _factory = new UserFactory();
        }

        public IActionResult ProfileModification()
        {
            var hero = GetCurrentUser().Hero;
            return View(hero);
        }
        
        
        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ProfileModification(UserModificationViewModel viewModel)
        {
            var user = GetCurrentUser();
            if (!ModelState.IsValid) return View(user.Hero);
            
            var updateUser = _factory.UpdateUser(user, viewModel.Name, viewModel.ImagePath);
            _dbContext.Update(updateUser);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
        
        private User GetCurrentUser()
        {
            var t = _manager.GetUserId(HttpContext.User);
            return GetUserById(t);

        }
        
        
        /**
         * Retourne l'utilisateur sur base de son ID.
         */
        private User GetUserById(string id) => _dbContext.Users.Include(h => h.Hero).Single(u => u.Id == id);
        
    }
}