using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Models;

namespace Project_C.Data
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int accept_invitation { get; set; }

        public List<UserRole> Roles { get; set; }

    }
}
