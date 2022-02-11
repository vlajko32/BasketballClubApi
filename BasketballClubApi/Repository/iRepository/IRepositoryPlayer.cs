using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositoryPlayer: IRepository<Player>
    {
        List<Player> FindByString(string search);

        List<Player> FindWithoutSelection();
    }
}
