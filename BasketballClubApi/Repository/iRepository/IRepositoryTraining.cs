using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositoryTraining: IRepository<Training>
    {
        /// <summary>
        /// Metoda za vracanje treninga po salama iz baze
        /// </summary>
        /// <param name="GymID"></param>
        /// <returns></returns>
        List<Training> FindByGym(int GymID);

    }
}
