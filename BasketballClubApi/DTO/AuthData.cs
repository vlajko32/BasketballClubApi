using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.DTO
{
    public class AuthData
    {
        public User User { get; set; }

        public Coach Coach { get; set; }

        public Administrator Administrator { get; set; }

        public string Token { get; set; }


        public IEnumerable<string> Errors { get; set; }
    }
}
