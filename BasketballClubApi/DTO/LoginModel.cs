using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    /// <summary>
    /// Klasa koja definise model za prijavljivanje korisnika na sistem
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
