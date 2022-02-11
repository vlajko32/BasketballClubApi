using System.Collections.Generic;

namespace BasketballClub_Rest.Domain
{
    public class Gym
    {

        public int GymID { get; set; }

        public string GymName { get; set; }

        public string Adress { get; set; }

        public List<Training> Trainings { get; set; }
    }
}