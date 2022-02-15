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
        public int SelectionID { get; set; }

        public SelectionAge SelectionAge { get; set; }

        public int SelectionAgeID { get; set; }

        public string SelectionName { get; set; }

        public List<Coach> Coaches { get; set; }

        public List<Player> Players { get; set; }

        public List<Training> Trainings { get; set; }
    }
}
