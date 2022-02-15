using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositoryAdministrator : IRepositoryAdministrator
    {
        private BCContext context;

        public RepositoryAdministrator(BCContext context)
        {
            this.context = context;
        }

        public void Delete(Administrator item)
        {
            throw new NotImplementedException();
        }

        public Administrator FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Administrator> GetAll()
        {
            throw new NotImplementedException();
        }

        public Administrator Insert(Administrator item)
        {
            if(context.Operators.Add(item)==null)
            {
                return null;
            }
            return item;
        }

        public Administrator Update(Administrator item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
