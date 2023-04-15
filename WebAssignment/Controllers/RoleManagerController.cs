using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAssignment.Areas.Identity.Data;

namespace WebAssignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<WebAssignmentUser> _userManager;


        public RoleManagerController(RoleManager<IdentityRole> roleManager, UserManager<WebAssignmentUser> userManager )
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoles(string roleName)
        {
            if(roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return Redirect("Index");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Main()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ViewItems()
        {
            return RedirectToAction("Index", "Item") ;
        }
    }
}
