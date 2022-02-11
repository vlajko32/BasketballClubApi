using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    public class SelectionModel
    {
        [Required]
        public string SelectionName { get; set; }

        [Required]
        public int SelectionAgeID { get; set; }


        public List<Player> AddedPlayers { get; set; }

        public List<Player> RemovedPlayers { get; set; }

        public List<Coach> AddedCoaches { get; set; }
        public List<Coach> RemovedCoaches { get; set; }


    }
}
