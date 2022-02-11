using BasketballClub_Rest.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
       public IRepositoryCoach Coaches { get; set; }

        public IRepositoryAdministrator Administrators { get; set; }

        public IRepositoryPlayer Players { get; set; }

        public IRepositorySelection Selections { get; set; }

        public IRepositoryTraining Trainings { get; set; }

        public IRepositoryUser Users { get; set; }

        public IRepositoryGym Gyms { get; set; }

        void Commit();

        void Dispose();
    }
}
