using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    /// <summary>
    /// Klasa koja definise model za kreiranje trenera
    /// </summary>
    public class CoachModel
    {
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public int YearsOfExperience { get; set; }

        public int SelectionID { get; set; }
    }
}
