using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    public class TrainingService
    {
        private readonly IUnitOfWork uow;

        public TrainingService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Training> GetAll()
        {
            return uow.Trainings.GetAll();
        }

        public List<Training> GetByGym(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }

            return uow.Trainings.FindByGym(id);
        }

        public Training Create(Training training)
        {
            try
            {
                Training t = uow.Trainings.Insert(training);
                uow.Commit();
                return t;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


           
        }
    }
}
