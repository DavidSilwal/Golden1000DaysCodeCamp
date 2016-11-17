using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Child
    {
        [Key]
        public int ChildID { get; set; }

        public string Name { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset DOB { get; set; }


        public IEnumerable<VacDone> VacDones { get; set; }

      
        public int MotherID { get; set; }
        public Mother Mother { get;  set; }
       
    }



}
