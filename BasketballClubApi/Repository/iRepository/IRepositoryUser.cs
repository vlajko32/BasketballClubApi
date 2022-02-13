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
        /// <summary>
        /// Metoda za nalazenje odredjenog korisnika iz baze
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        User FindOne(Expression<Func<User, bool>> func);
        /// <summary>
        /// Metoda za vracanje registracionih kodova iz baze
        /// </summary>
        /// <returns></returns>
        List<Code> GetCodes();
    }
}
