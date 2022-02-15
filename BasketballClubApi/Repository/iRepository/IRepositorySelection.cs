using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositorySelection: IRepository<Selection>
    {
        /// <summary>
        /// Metoda za vracanje svih uzrasta iz baze
        /// </summary>
        /// <returns></returns>
        List<SelectionAge> GetAllAges();

    }
}
