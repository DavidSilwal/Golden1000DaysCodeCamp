using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class VacDone
    {
        [Key]
        public int VacDoneID { get; set; }

      
        public Mother Mother { get;  set; }
        public int MotherID { get;  set; }
     
    }
}
