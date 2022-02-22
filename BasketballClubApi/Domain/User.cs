using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na korisnike
    /// </summary>
    public class User
    {
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int UserID { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string Name { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string Surname { get; set; }
    }
}
