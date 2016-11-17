using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Data;

namespace WebApplication.Models
{
    public class DashboardViewModel
    {
        public Mother Mother { get; set; }

        public List<Pregnancy> Pregnancy { get; set; }
        public List<Child> Child { get; set; }
        public List<Checkups> Checkups { get; set; }
        public List<CheckupsDone> CheckupsDone { get; set; }
        public List<MotherExamination> MotherExamination { get; set; }
        public List<VacDone> VacDones { get; set; }



    }
}
