using System;
using System.ComponentModel.DataAnnotations;

namespace Project_C.Data
{
    public class SessionInfo
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255, MinimumLength = 1, ErrorMessage = "Vul hier de naam van de sessie in")]
        public string Name { get; set; }

        [Required, StringLength(255, MinimumLength = 1, ErrorMessage ="Vul hier de locatie van de sessie in")]
        public string Location { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }
    }
}
