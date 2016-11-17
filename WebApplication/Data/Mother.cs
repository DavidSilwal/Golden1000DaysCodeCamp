using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Mother
    {
        [Key]
        public int MotherID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }

        public IEnumerable<MotherExamination> Examinations { get;  set; }

        public IEnumerable<VacDone> VacDones { get;  set; }

     
        public IEnumerable<Child> Childs { get;  set; }
        public IEnumerable<CheckupsDone> CheckupsDones { get;  set; }
        public IEnumerable<Pregnancy> Pregnancies { get;  set; }
    }
}
