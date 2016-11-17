using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class MotherExamination
    {
        [Key]
        public int ExaminationID { get; set; }

        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string BloodPressure { get; set; }

        [Display(Name ="Amount Of HB/100ML")]
        public string HBTest { get; set; }

        
        [DataType(DataType.MultilineText)]
        public string Complication { get; set; }
        [DataType(DataType.MultilineText)]
        public string Advice { get; set; }
        [DataType(DataType.MultilineText)]
        public string Medication { get; set; }
        public Mother Mother { get;  set; }
        public int MotherID { get;  set; }
    }
}
