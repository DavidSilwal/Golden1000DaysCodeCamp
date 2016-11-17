using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class CheckupsDone
    {
        [Key]
        public int CheckupsDoneID { get; set; }
        public Mother Mother { get;  set; }
        public int MotherID { get;  set; }
        public string Patients { get; set; }
        
              
    }
}
