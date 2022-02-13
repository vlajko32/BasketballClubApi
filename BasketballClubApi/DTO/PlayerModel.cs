using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    /// <summary>
    /// Klasa koja definise model za kreiranje igraca
    /// </summary>
    public class PlayerModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public int SelectionID { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }
    }
}
