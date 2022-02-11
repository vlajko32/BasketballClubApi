using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasketballClub_Rest.Controllers
{
    [Route("api/training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private IUnitOfWork uow;


        public TrainingController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        //[Authorize(Roles = "Operator, Coach")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Training> trainings = uow.Trainings.GetAll();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public IActionResult GetByGym(int id)
        {
            List<Training> trainings = uow.Trainings.FindByGym(id);
            return Ok(trainings);
        }


        //[Authorize(Roles = "Coach")]

        [HttpPost("create")]
        public IActionResult Create([FromBody] TrainingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Training training = new Training
            {
                TrainingStart = model.TrainingStart,
                TrainingEnd = model.TrainingEnd,
                CoachID = model.CoachID,
                SelectionID = model.SelectionID,
                GymID = model.GymID
            };

            uow.Trainings.Insert(training);
            uow.Commit();

            return Ok();
        }

        //[Authorize(Roles = "Operator, Coach")]

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Training training = uow.Trainings.FindById(id);
            if (training == null)
            {
                return BadRequest();
            }
            uow.Trainings.Delete(training);
            uow.Commit();

            return Ok();
        }
       
    }
}
