using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Pregnancy
    {
        [Key]
        public int PregnancyID { get; set; }
     
        [Display(Name="No of times of Pregnancy")]
        public int PregNo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Last Mensuration Date")]
        public DateTimeOffset LMD { get; set; }

        public int MotherID { get; set; }

        public Mother Mother { get;  set; }
    


        //public DateTimeOffset EDD { 

        //    get
        //    {
        //        return this.LMD + 280 ;
        //    }
        //}


    }
}
