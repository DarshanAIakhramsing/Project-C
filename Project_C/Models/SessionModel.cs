using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_C.Models
{
    public class SessionModel
    {
        [Key]

        public int session_id { get; set; }

        public string session_name { get; set; }

        public DateTime session_date { get; set; }

        public string session_location { get; set; }
    }
}
