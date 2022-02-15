using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Domain
{
    /// <summary>
    /// Klasa koja se odnosi na korisnike
    /// </summary>
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
