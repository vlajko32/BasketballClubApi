using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na uzrast
    /// </summary>
    public class SelectionAge
    {
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int SelectionAgeID { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string SelectionAgeName { get; set; }
    }
}
