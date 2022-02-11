using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositoryPlayer : IRepositoryPlayer
    {
        private BCContext context;

        public RepositoryPlayer(BCContext context)
        {
            this.context = context;
        }

        public void Delete(Player item)
        {
            context.Players.Remove(item);
        }

        public Player FindById(int id)
        {
            return context.Players.Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).SingleOrDefault(pl => pl.PlayerID == id);
        }

        public List<Player> FindByString(string searchText)
        {
            
            return context.Players.Where(p=> $"{p.Name} {p.Surname}".Contains(searchText) || $"{p.Surname} {p.Name}".Contains(searchText)).Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).ToList();
        }

        public List<Player> FindByAge(int bornYear)
        {

            return context.Players.Where(p => p.BirthDate.Year == bornYear).Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).ToList();
        }

        public List<Player> GetAll()
        {
            return context.Players.Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).ToList();
        }

        public void Insert(Player item)
        {
            context.Players.Add(item);
        }

        public void Update(Player item, int id)
        {
            Player updated = context.Players.Find(id);
            updated.SelectionID = item.SelectionID;
            updated.Weight = item.Weight;
            updated.Height = item.Height;
            if (updated.SelectionID == 0)
            {
                updated.SelectionID = null;
            }
            context.Players.Update(updated);
        }

        public List<Player> FindWithoutSelection()
        {
            return context.Players.Where(p => p.SelectionID == null).ToList();
            
        }
    }
}
