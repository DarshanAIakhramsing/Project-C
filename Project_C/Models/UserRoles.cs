using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Models;

namespace Project_C.Models
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }

        public User UserName { get; set; }

        public Roles RolesName { get; set; }

    }
}
