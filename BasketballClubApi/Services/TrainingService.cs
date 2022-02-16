using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    /// <summary>
    /// Klasa koja predstavlja servis za pozivanje operacija nad tabelom Trainings u bazi
    /// </summary>
    public class TrainingService
    {
        private readonly IUnitOfWork uow;
        /// <summary>
        /// Parametarski kontstruktor koji inicijalizuje UoW
        /// </summary>
        /// <param name="uow"></param>
        public TrainingService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Metoda koja vraca sve postojece treninge iz baze
        /// </summary>
        /// <returns>Lista treninga</returns>
        public List<Training> GetAll()
        {
            return uow.Trainings.GetAll();
        }
        /// <summary>
        /// Metoda koja iz baze vraca treninge po odredjenim salama
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista treninga za trazenu salu</returns>
        public List<Training> GetByGym(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }

            return uow.Trainings.FindByGym(id);
        }
        /// <summary>
        /// Metoda koja kreira novi trening u bazi
        /// </summary>
        /// <param name="training"></param>
        /// <returns>Trening ukoliko je operacija uspesno obavljena</returns>
        public Training Create(Training training)
        {
            if(training ==null)
            {
                throw new NullReferenceException();
            }
            try
            {
                Training t = uow.Trainings.Insert(training);
                uow.Commit();
                return t;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


           
        }
    }
}
