using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_C.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
