using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    public class RegisterModel
    {
        [Required]
        public string Role { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Surname { get; set; }

        public int YearsOfExperience { get; set; }

        public int SelectionID { get; set; }

        public string Code { get; set; }


    }
}
