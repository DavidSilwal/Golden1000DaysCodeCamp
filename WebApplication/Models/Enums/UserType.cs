using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Enums
{
    public enum UserType
    {
        [Display(Name = "Administrator")]
        ADMIN,

        [Display(Name = "Doctor")]
        DOCTOR,

        [Display(Name = "Health Worker")]
        HEALTH_WORKER,
            
      
        [Display(Name = "Normal User")]
        NORMAL_USER
    }
}
