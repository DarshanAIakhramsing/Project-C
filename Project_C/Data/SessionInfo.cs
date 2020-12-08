using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project_C.Models;

namespace Project_C.Data
{
    public class SessionInfo
    {
        [Key]

        public int session_id { get; set; }

        public string session_name { get; set; }

        public DateTime session_date { get; set; }

        public string session_location { get; set; }

    }
}
