using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class ViewModelService : IViewModelService
    {
        protected readonly ApplicationDbContext _context;

        public ViewModelService(ApplicationDbContext context)
        {
            _context = context;
        }


        public DashboardViewModel GetDashboardViewModel()
        {
            return new DashboardViewModel
            {
                Mother = _context.Mothers.FirstOrDefault(),
               
                //Child = _context.Child.OrderBy(b=>b.Name).ToList(),
                //Checkups = _context.Checkups.ToList(),
                //VacDones = _context.VacDone.ToList(),
                //Pregnancy = _context.Pregnancy.ToList(),
                //CheckupsDone = _context.CheckupsDone.ToList(),
                //MotherExamination = _context.Examination.ToList()

            };

        }


    }
}
