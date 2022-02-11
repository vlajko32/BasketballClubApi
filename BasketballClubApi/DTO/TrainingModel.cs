using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    public class TrainingModel
    {
        public DateTime TrainingStart { get; set; }

        public DateTime TrainingEnd { get; set; }



        public int CoachID { get; set; }

        public int GymID { get; set; }

        public int SelectionID { get; set; }




    }
}
