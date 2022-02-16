using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Services
{
    public class CoachService
    {
        private readonly IUnitOfWork uow;

        public CoachService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Coach> GetAll()
        {
            return uow.Coaches.GetAll();
        }

        public Coach GetByID(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id");
            }

            return uow.Coaches.FindById(id);
            

        }
        public List<Coach> GetWithoutSelection()
        {
            return uow.Coaches.GetWithoutSelection();
        }

        public void Delete(int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");

            }
            Coach coach = uow.Coaches.FindById(id);
            if (coach == null)
            {
                throw new Exception("Coach with that id does not exist!");
            }
            uow.Coaches.Delete(coach);
            uow.Commit();
        }

        public Coach Update(CoachModel model, int id)
        {
            if(id<=0)
            {
                throw new Exception("Invalid id!");
            }
            Coach coach = uow.Coaches.FindById(id);
            coach.YearsOfExperience = model.YearsOfExperience;
            coach.SelectionID = model.SelectionID;
            if (coach.SelectionID == 0)
            {
                coach.SelectionID = null;
            }
            try
            {
                Coach c = uow.Coaches.Update(coach, id);
                uow.Commit();
                return c;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            
        }
    }
}
