using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositoryGym : IRepositoryGym
    {
        private BCContext context;

        public RepositoryGym(BCContext context)
        {
            this.context = context;
        }
        public void Delete(Gym item)
        {
            throw new NotImplementedException();
        }

        public Gym FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gym> GetAll()
        {
            return context.Gyms.ToList();
        }

        public Gym Insert(Gym item)
        {
            throw new NotImplementedException();
        }

        public Gym Update(Gym item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
