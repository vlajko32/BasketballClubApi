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

        public PlayerService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Player Create(Player player)
        {
            if(player==null)
            {
                throw new NullReferenceException();
            }

            Player pl = uow.Players.Insert(player);
            uow.Commit();
            return pl;
        }

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

        public List<Player> GetAll()
        {
            return uow.Players.GetAll();
        }

        public List<Player> FindByString(string search)
        {
            return uow.Players.FindByString(search);
        }

        public List<Player> FindWithoutSelection()
        {
            return uow.Players.FindWithoutSelection();
        }

        public Player FindByID(int id)
        {
            return uow.Players.FindById(id);
        }

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
