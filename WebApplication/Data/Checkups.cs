using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Checkups
    {

        [Key]
        public int CheckupsID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset Period { get; set; }

        public string Patients { get; set; }


    }



}
