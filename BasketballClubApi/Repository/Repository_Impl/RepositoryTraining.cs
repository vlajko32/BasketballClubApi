using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositoryTraining : IRepositoryTraining
    {
        private BCContext context;
        public RepositoryTraining(BCContext context)
        {
            this.context = context;
        }
        public void Delete(Training item)
        {
            context.Trainings.Remove(item);
        }

        public List<Training> FindByGym(int GymID)
        {
            return context.Trainings.Include(c=>c.Coach).Include(s=>s.Selection).Where(t => t.GymID == GymID).ToList();
        }

        public Training FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Training> GetAll()
        {
            return context.Trainings.Include(s => s.Selection).Include(c => c.Coach).Include(g => g.Gym).ToList();
        }

        public Training Insert(Training item)
        {
            if(context.Trainings.Add(item)==null)
            {
                return null;
            }
            return item;
        }

        public Training Update(Training item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
