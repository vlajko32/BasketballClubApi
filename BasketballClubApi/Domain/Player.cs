using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na igrace
    /// </summary>
    public class Player
    {
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int PlayerID { get; set; }
        [NameLengthValidation(ErrorMessage ="Must be longer than 2 characters")]
        public string Name { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string Surname { get; set; }
        [HeightValidation(ErrorMessage =("Must be between 90 and 235"))]
        public int? Height { get; set; }
        [HeightValidation(ErrorMessage = ("Must be between 30 and 160"))]

        public int? Weight { get; set; }
        [BirthYearValidation(ErrorMessage =("Cannot be born before 1980"))]
        public DateTime BirthDate { get; set; }

        
        public Selection Selection { get; set; }
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int? SelectionID { get; set; }
    }
}
