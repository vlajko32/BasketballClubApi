using BasketballClub_Rest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Metoda za registrovanje korisnika na sistem
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Korisnika ukoliko je uspesno registrovan, gresku ukoliko nije</returns>
        AuthData Register(RegisterModel model);
        /// <summary>
        /// Metoda za prijavljivanje korisnika
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Toren i korisnika ukoliko je uspesno prijavljen, odgovarajucu gresku ukoliko nije</returns>
        AuthData Login(LoginModel model);
    }
}
