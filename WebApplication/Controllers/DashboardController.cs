using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        protected IViewModelService _vm;

        public DashboardController(ApplicationDbContext context,
            IViewModelService vm)
        {
            _context = context;
            _vm = vm;
        }


        public IActionResult Index()
        {          

            return View(_vm.GetDashboardViewModel());
        }
    }
}
