using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositoryPlayer: IRepository<Player>
    {
        /// <summary>
        /// Metoda za pretrazivanje igraca iz baze pomocu imena ili prezimena
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        List<Player> FindByString(string search);
        /// <summary>
        /// Metoda za vracanje iz baze svih igraca koji nemaju selekciju
        /// </summary>
        /// <returns></returns>
        List<Player> FindWithoutSelection();
    }
}
