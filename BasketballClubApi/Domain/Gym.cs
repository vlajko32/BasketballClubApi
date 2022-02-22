using BasketballClubApi.Validation;
using System.Collections.Generic;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na sale za treninge
    /// </summary>
    public class Gym
    {
        [IDValidation(ErrorMessage = ("ID must be greater than 0"))]

        public int GymID { get; set; }
        [NameLengthValidation(ErrorMessage = "Must be longer than 2 characters")]

        public string GymName { get; set; }

        public string Adress { get; set; }

        public List<Training> Trainings { get; set; }
    }
}