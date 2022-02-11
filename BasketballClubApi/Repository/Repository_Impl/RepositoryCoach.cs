using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositoryCoach : IRepositoryCoach
    {
        private BCContext context;

        public RepositoryCoach(BCContext context)
        {
            this.context = context;
        }

        public void Delete(Coach item)
        {
            throw new NotImplementedException();
        }

        public Coach FindById(int id)
        {
            return context.Coaches.Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).
                Include(s => s.Selection).ThenInclude(p=>p.Players).
                 Include(s => s.Selection).ThenInclude(p => p.Coaches).
                 SingleOrDefault(us => us.UserID == id);
        }

        public List<Coach> GetAll()
        {
            return context.Coaches.Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).ToList();
        }

        public List<Coach> GetWithoutSelection()
        {
            return context.Coaches.Where(c=> c.SelectionID==null).Include(s => s.Selection).ThenInclude(sa => sa.SelectionAge).ToList();
        }

        public void Insert(Coach item)
        {
            context.Coaches.Add(item);
        }

        public void Update(Coach item, int id)
        {
            Coach updated = context.Coaches.Find(id);
            updated.SelectionID = item.SelectionID;
            updated.YearsOfExperience = item.YearsOfExperience;
            context.Coaches.Update(updated);
        }
    }
}
