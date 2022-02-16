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
    /// Klasa koja sluzi kao servis za pozivanje operacija nad tabelom Selections u bazi
    /// </summary>
    public class SelectionService
    {
        private readonly IUnitOfWork uow;
        /// <summary>
        /// Parametarski kontstruktor koji inicijalizuje UoW
        /// </summary>
        /// <param name="uow"></param>
        public SelectionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// Metoda koja vraca sve selekcije iz baze
        /// </summary>
        /// <returns>Lista selekcija</returns>
        public List<Selection> GetAll()
        {
            return uow.Selections.GetAll();
        }
        /// <summary>
        /// Metoda koja vraca sve uzraste selekcija iz baze
        /// </summary>
        /// <returns>Lista uzrasta</returns>
        public List<SelectionAge> GetAllAges()
        {
            return uow.Selections.GetAllAges();
        }
        /// <summary>
        /// Metoda koja vraca selekciju sa trazenim id-jem iz baze
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Selekcija</returns>
        public Selection GetByID(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id");
            }

            Selection s = uow.Selections.FindById(id);
            return s;
        }
        /// <summary>
        /// Metoda koja azurira podatke o postojecoj selekciji u bazi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>Selekciju ukoliko je operacija uspesno obavljena</returns>
        public Selection Update(SelectionModel model, int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }
            Selection s = new Selection
            {
                SelectionName = model.SelectionName,

                SelectionAgeID = model.SelectionAgeID
            };

            if (model.AddedPlayers != null && model.AddedPlayers.Count > 0)
            {
                foreach (Player p in model.AddedPlayers)
                {
                    Player player = uow.Players.FindById(p.PlayerID);
                    player.SelectionID = id;
                    uow.Players.Update(player, p.PlayerID);
                }
            }
            if (model.RemovedPlayers != null && model.RemovedPlayers.Count > 0)
            {
                foreach (Player p in model.RemovedPlayers)
                {
                    Player player = uow.Players.FindById(p.PlayerID);
                    player.SelectionID = null;
                    uow.Players.Update(player, p.PlayerID);
                }
            }
            if (model.AddedCoaches != null && model.AddedCoaches.Count > 0)
            {
                foreach (Coach c in model.AddedCoaches)
                {
                    Coach coach = uow.Coaches.FindById(c.UserID);
                    coach.SelectionID = id;
                    uow.Coaches.Update(coach, c.UserID);
                }
            }

            if (model.RemovedCoaches != null && model.RemovedCoaches.Count > 0)
            {
                foreach (Coach c in model.RemovedCoaches)
                {
                    Coach coach = uow.Coaches.FindById(c.UserID);
                    coach.SelectionID = null;
                    uow.Coaches.Update(coach, c.UserID);
                }
            }

            uow.Selections.Update(s, id);
            uow.Commit();
            return s;

        }
        /// <summary>
        /// Metoda koja kreira novu selekciju u bazi
        /// </summary>
        /// <param name="selection"></param>
        /// <returns>Selekciju ukoliko je operacija uspesno obavljena</returns>
        public Selection Create(Selection selection)
        {
            if(selection == null)
            {
                throw new NullReferenceException();
            }
            Selection s = uow.Selections.Insert(selection);

            uow.Commit();
            return s;
        }
        /// <summary>
        /// Metoda koja iz baze brise selekciju sa trazenim id-jem
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }
            Selection selection = uow.Selections.FindById(id);
            if (selection == null)
            {
                throw new Exception("There is no selection with that id");
            }
            
            uow.Selections.Delete(selection);
            uow.Commit();
            
        }

    }
}
