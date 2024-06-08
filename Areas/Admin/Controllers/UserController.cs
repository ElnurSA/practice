using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProjectFinal.Models;
using FiorelloProjectFinal.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UserRolesVm> userRoles = new();
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                string rolesStr = string.Join(",", roles.ToArray());

                userRoles.Add(new UserRolesVm
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Roles = rolesStr,
                    Username = user.UserName

                });
            }
            return View(userRoles);
        }
    }
}

