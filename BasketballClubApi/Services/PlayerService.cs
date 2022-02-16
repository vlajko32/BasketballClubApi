using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    /// <summary>
    /// Klasa koja sluzi kao servis za pozivanje operacija nad tabelom Players u bazi
    /// </summary>
    public class PlayerService
    {
        private readonly IUnitOfWork uow;
        /// <summary>
        /// Parametarski kontstruktor koji inicijalizuje UoW
        /// </summary>
        /// <param name="uow"></param>
        public PlayerService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// Metoda koja sluzi za kreiranje novog igraca u bazi
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Igraca ukoliko je operacija uspesno obavljena</returns>
        public Player Create(Player player)
        {
            if(player==null)
            {
                throw new NullReferenceException();
            }
            try
            {
                Player pl = uow.Players.Insert(player);
                uow.Commit();
                return pl;
            }
            catch (Exception)
            {
                throw new Exception("Invalid selection ID!");
            }
           
        }
        /// <summary>
        /// Metoda koja sluzi za azuriranje podataka o postojecem igracu u bazi
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        /// <returns>Igraca ukoliko je operacija uspesno obavljena</returns>
        public Player Update(Player item, int id)
        {
            Player player = uow.Players.FindById(id);
            if(player == null)
            {
                throw new Exception("There is no player with given id");
            }
            player.SelectionID = item.SelectionID;
            player.Height = item.Height;
            player.Weight = item.Weight;

            if (id < 0)
            {
                throw new Exception("Invalid id!");
            }
            if(item == null)
            {
                throw new NullReferenceException();
            }

            Player p = uow.Players.Update(player, id);
            uow.Commit();
            return p;

        }
        /// <summary>
        /// Metoda koja vraca sve postojece igrace iz baze
        /// </summary>
        /// <returns>Lista igraca</returns>
        public List<Player> GetAll()
        {
            return uow.Players.GetAll();
        }
        /// <summary>
        /// Metoda koja pretrazuje i vraca iz baze igrace na osnovu datog parametra
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Lista igraca koji odgovaraju datom parametru</returns>
        public List<Player> FindByString(string search)
        {
            return uow.Players.FindByString(search);
        }
        /// <summary>
        /// Metoda koja vraca igrace koji nemaju selekciju iz baze
        /// </summary>
        /// <returns>Lista igraca bez selekcije</returns>
        public List<Player> FindWithoutSelection()
        {
            return uow.Players.FindWithoutSelection();
        }
        /// <summary>
        /// Metoda koja pronalazi i vraca igraca iz baze na osnovu id-ja
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Igrac sa datim id-jem</returns>
        public Player FindByID(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }
            return uow.Players.FindById(id);
        }
        /// <summary>
        /// Metoda koja brise u bazi igraca sa datim id-jem
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {

            if (id < 0)
            {
                throw new Exception("Invalid id!");
            }
            Player player = uow.Players.FindById(id);
            if (player == null)
            {
                throw new Exception("Player with that id does not exist!");
            }
            uow.Players.Delete(player);
            uow.Commit();
        }


    }
}
