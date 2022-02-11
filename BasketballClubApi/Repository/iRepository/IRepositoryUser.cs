using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositoryUser: IRepository<User>
    {
        User FindOne(Expression<Func<User, bool>> func);

        List<Code> GetCodes();
    }
}
