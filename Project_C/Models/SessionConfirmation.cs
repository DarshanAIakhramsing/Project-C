using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Data;
using Project_C.Models;
using System.ComponentModel.DataAnnotations;

namespace Project_C.Models
{
    public class SessionConfirmation
    {
        
        public int Id { get; set; }

        public string Email { get; set; }

        public int AcceptedInvites { get; set; }
    }
}
