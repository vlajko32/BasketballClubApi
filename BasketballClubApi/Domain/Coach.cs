using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    public class Coach: User
    {
     

        public int YearsOfExperience { get; set; }

        public Selection Selection { get; set; }

        public int? SelectionID { get; set; }

        public List<Training> Trainings { get; set; }

    }
}
