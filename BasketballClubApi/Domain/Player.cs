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
        public int PlayerID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public DateTime BirthDate { get; set; }

        
        public Selection Selection { get; set; }

        public int? SelectionID { get; set; }
    }
}
