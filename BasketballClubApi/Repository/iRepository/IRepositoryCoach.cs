using BasketballClub_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepositoryCoach : IRepository<Coach>
    {
        List<Coach> GetWithoutSelection();
    }
}
