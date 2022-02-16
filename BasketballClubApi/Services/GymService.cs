using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    /// <summary>
    /// Klasa koja predstavlja servis za rad sa pozivanje operacija nad tabelom Gyms u bazi
    /// </summary>
    public class GymService
    {
        private readonly IUnitOfWork uow;
        /// <summary>
        /// Parametarski kontstruktor koji inicijalizuje UoW
        /// </summary>
        /// <param name="uow"></param>
        public GymService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// Metoda koja iz baze vraca sve sale za treniranje
        /// </summary>
        /// <returns>Lista sala</returns>
        public List<Gym> GetAll()
        {
            return uow.Gyms.GetAll();
        }

    }
}
