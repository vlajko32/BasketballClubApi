using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using BasketballClub_Rest.Repository.Repository_Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.UnitOfWork
{
    public class BCUnitOfWork : IUnitOfWork
    {
        private BCContext context;

        public BCUnitOfWork(BCContext context)
        {
            this.context = context;

            Coaches = new RepositoryCoach(context);
            Administrators = new RepositoryAdministrator(context);
            Users = new RepositoryUser(context);
            Players = new RepositoryPlayer(context);
            Selections = new RepositorySelection(context);
            Trainings = new RepositoryTraining(context);
            Gyms = new RepositoryGym(context);
        }

        public IRepositoryCoach Coaches { get; set;  }
        public IRepositoryAdministrator Administrators { get; set; }
        public IRepositoryPlayer Players { get; set; }
        public IRepositorySelection Selections { get; set; }
        public IRepositoryTraining Trainings { get; set; }

        public IRepositoryGym Gyms { get; set; }
        public IRepositoryUser Users { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
         }
    }
}
