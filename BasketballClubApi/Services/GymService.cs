using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    public class GymService
    {
        private readonly IUnitOfWork uow;

        public GymService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Gym> GetAll()
        {
            return uow.Gyms.GetAll();
        }

    }
}
