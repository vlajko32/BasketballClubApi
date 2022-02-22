using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na selekcije
    /// </summary>
    public class Selection
    {
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int SelectionID { get; set; }

        public SelectionAge SelectionAge { get; set; }
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int SelectionAgeID { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string SelectionName { get; set; }

        public List<Coach> Coaches { get; set; }

        public List<Player> Players { get; set; }

        public List<Training> Trainings { get; set; }
    }
}
