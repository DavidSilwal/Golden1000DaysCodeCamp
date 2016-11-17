using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.Enums;

namespace WebApplication.Controllers
{
    public class InstallController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger _logger;

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private ApplicationDbContext _context;

        public InstallController(
            ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<InstallController>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(InstallationViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var permissions = new List<Permission>()
                {
                 
                    new Permission() { Group = "user_management", Name = "CREATE_USERS", Description = "Create Users" },
                    new Permission() { Group = "user_management", Name = "EDIT_USERS", Description = "Edit Users" },
                    new Permission() { Group = "user_management", Name = "VIEW_USERS", Description = "View Users" },
                    new Permission() { Group = "user_management", Name = "DELETE_USERS", Description = "Delete Users" },

                    new Permission() { Group = "administration", Name = "CREATE_LOCATIONS", Description = "Create Locations" },
                    new Permission() { Group = "administration", Name = "EDIT_LOCATIONS", Description = "Edit Locations" },
                    new Permission() { Group = "administration", Name = "VIEW_LOCATIONS", Description = "View Locations" },
                    new Permission() { Group = "administration", Name = "DELETE_LOCATIONS", Description = "Delete Locations" },

                };

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(permission);
                }

                _context.SaveChanges();

                //var roles = new List<Role>()
                //{
                //    new Role() { Name = "Administrator" }
                //};

                var user = new User
                {
                    UserName = model.UserName,
                    UserType = UserType.NORMAL_USER
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var adminRole = new Role()
                    {
                        Name ="Admin"
                       
                    };

                    result = await _roleManager.CreateAsync(adminRole);

                    if (result.Succeeded)
                    {
                        foreach (var _permission in _context.Permissions)
                        {
                            _context.RolePermissions.Add(new RolePermission()
                            {
                                RoleId = adminRole.Id,
                                PermissionId = _permission.Id
                            });
                        }

                        _context.SaveChanges();

                        await _userManager.AddToRoleAsync(user, adminRole.Name);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            return View(model);
        }
    }
}
