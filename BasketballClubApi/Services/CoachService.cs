using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    /// <summary>
    /// Klasa koja predstavlja servis za pozivanje operacija nad tabelom Coaches u bazi
    /// </summary>
    public class CoachService
    {
        private readonly IUnitOfWork uow;
        /// <summary>
        /// Konstruktor sa parametrom koji inicijalizuje UoW
        /// </summary>
        /// <param name="uow"></param>
        public CoachService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Metoda koja iz baze vraca sve trenere
        /// </summary>
        /// <returns>Lista trenera</returns>
        public List<Coach> GetAll()
        {
            return uow.Coaches.GetAll();
        }

        /// <summary>
        /// Metoda koja vraca trenera sa trazenim id-jem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Coach GetByID(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id");
            }

            return uow.Coaches.FindById(id);
            

        }
        /// <summary>
        /// Metoda koja vraca iz baze sve trenere bez selekcije
        /// </summary>
        /// <returns>Lista trenera bez selekcije</returns>
        public List<Coach> GetWithoutSelection()
        {
            return uow.Coaches.GetWithoutSelection();
        }
        /// <summary>
        /// Metoda koja brise trenera sa datim id-jem iz baze
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");

            }
            Coach coach = uow.Coaches.FindById(id);
            if (coach == null)
            {
                throw new Exception("Coach with that id does not exist!");
            }
            uow.Coaches.Delete(coach);
            uow.Commit();
        }

        /// <summary>
        /// Metoda koja sluzi za azuriranje podataka o postojecem treneru u bazi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>Azuriranog trenera ukoliko je operacija uspesno obavljena</returns>
        public Coach Update(CoachModel model, int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }
            Coach coach = uow.Coaches.FindById(id);
            coach.YearsOfExperience = model.YearsOfExperience;
            coach.SelectionID = model.SelectionID;
            if (coach.SelectionID == 0)
            {
                coach.SelectionID = null;
            }
            try
            {
                Coach c = uow.Coaches.Update(coach, id);
                uow.Commit();
                return c;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            
        }
    }
}
