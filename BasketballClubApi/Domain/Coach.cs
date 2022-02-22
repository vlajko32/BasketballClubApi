using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na trenere
    /// </summary>
    public class Coach: User
    {
     
        [YearsOfExperienceValidation(ErrorMessage = ("Years of experience must be greater than 0 and cannot be greater than 50"))]
        public int YearsOfExperience { get; set; }

        public Selection Selection { get; set; }
        [IDValidation(ErrorMessage =("ID must be greater than 0"))]
        public int? SelectionID { get; set; }

        public List<Training> Trainings { get; set; }

    }
}
