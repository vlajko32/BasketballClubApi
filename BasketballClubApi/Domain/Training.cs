using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na treninge
    /// </summary>
    public class Training
    {
        public int TrainingID { get; set; }

        public DateTime TrainingStart { get; set; }

        public DateTime TrainingEnd { get; set; }


        public Selection Selection { get; set; }

        public int SelectionID { get; set; }

        public Gym Gym { get; set; }

        public int GymID { get; set; }

        public Coach Coach { get; set; }

        public int CoachID { get; set; }

    }
}
