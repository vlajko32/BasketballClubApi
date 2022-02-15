using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositoryUser : IRepositoryUser
    {
        private BCContext context;

        public RepositoryUser(BCContext context)
        {
            this.context = context;
        }

        public void Delete(User item)
        {
            context.Users.Remove(item);
        }

        public User FindById(int id)
        {
            return context.Users.SingleOrDefault(us => us.UserID == id);
        }

        public User FindOne(Expression<Func<User, bool>> func)
        {
            return context.Users.SingleOrDefault(func);
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Code> GetCodes()
        {
            return context.Codes.ToList();
        }

        public User Insert(User item)
        {
            throw new NotImplementedException();
        }

        public User Update(User item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
