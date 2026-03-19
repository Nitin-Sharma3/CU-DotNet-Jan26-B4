using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Day61_01.Models.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Day61_01.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var model = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.Add(new UserRolesViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = string.Join(", ", roles)
                });
            }

            return View(model);
        }
    }
}
