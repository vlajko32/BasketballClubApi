using System.Collections.Generic;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na sale za treninge
    /// </summary>
    public class Gym
    {

        public int GymID { get; set; }

        public string GymName { get; set; }

        public string Adress { get; set; }

        public List<Training> Trainings { get; set; }
    }
}