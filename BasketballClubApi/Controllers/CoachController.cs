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
    [Route("api/coach")]
    [ApiController]
  //  [Authorize(Roles = "Operator, Coach")]
    public class CoachController : ControllerBase
    {
        private IUnitOfWork uow;

        public CoachController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //[HttpPost("create")]
        //public IActionResult CreatePlayer([FromBody] CoachModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Coach player = new Coach
        //    {
        //        Name = model.Name,
        //        Surname = model.Surname,
        //        SelectionID = model.SelectionID,
        //        BirthDate = model.BirthDate,
        //    };

        //    uow.Players.Insert(player);
        //    uow.Commit();

        //    return Ok();

        //}
       // [Authorize(Roles = "Operator, Coach")]

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Coach> coaches = uow.Coaches.GetAll();
            return Ok(coaches);
        }
       // [Authorize(Roles = "Operator, Coach")]

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Coach coach = uow.Coaches.FindById(id);
            return Ok(coach);
        }

       // [Authorize(Roles = "Operator")]
        [HttpGet("withoutSelection")]
        public IActionResult GetWithoutSelection()
        {
            List<Coach> coaches = uow.Coaches.GetWithoutSelection();
            return Ok(coaches);
        }

      //  [Authorize(Roles = "Operator")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            User user = uow.Users.FindById(id);
            if (user == null)
            {
                return BadRequest();
            }
            uow.Users.Delete(user);
            uow.Commit();
            return Ok();
        }

      //  [Authorize(Roles = "Operator")]

        [HttpPut("{id}")]
        public IActionResult UpdateCoach([FromRoute] int id, [FromBody] CoachModel model)
        {
            Coach coach = uow.Coaches.FindById(id);
            coach.YearsOfExperience = model.YearsOfExperience;
            coach.SelectionID = model.SelectionID;
            if(coach.SelectionID==0)
            {
                coach.SelectionID = null;
            }
            uow.Coaches.Update(coach, id);
            uow.Commit();

            return Ok();
        }

      
    }
}
