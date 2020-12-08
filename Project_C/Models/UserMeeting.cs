using System;
using System.ComponentModel.DataAnnotations;
using Project_C.Data;
using Project_C.Models;

namespace Project_C.Models
{
    public class UserMeeting
    {
        //[Key]
        public User User { get; set; }
        public SessionInfo SessionInfo { get; set; }
    }
}
