using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Models;

namespace Project_C.Models
{
    public class UserRole
    {
        public User User { get; set; }
        public Role Role { get; set; }

    }
}
