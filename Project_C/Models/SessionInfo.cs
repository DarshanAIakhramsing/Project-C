using System;
using System.ComponentModel.DataAnnotations;

namespace Project_C.Data
{
    public class SessionInfo
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        [Required, StringLength(255, MinimumLength = 1)]
        public string Location { get; set; }

        public DateTime Date { get; set; }
    }
}
