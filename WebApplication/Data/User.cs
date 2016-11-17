using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models.Enums;

namespace WebApplication.Data
{
    public class User : IdentityUser<int>
    {
        public User() : base()
        {
           
            UserPermissions = new HashSet<UserPermission>();
     
        }

        public UserType UserType { get; set; }

     
        public virtual ICollection<UserPermission> UserPermissions { get; set; }


    
    }
}
