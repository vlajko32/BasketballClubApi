using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositoryCoach : IRepository<Coach>
    {
        /// <summary>
        /// Metoda za vracanje svih trenera iz baze koji ne treniraju nijednu selekciju
        /// </summary>
        /// <returns></returns>
        List<Coach> GetWithoutSelection();
    }
}
