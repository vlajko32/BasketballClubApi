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
    /// <summary>
    /// Kontroler za rad sa treninzima
    /// </summary>
    [Route("api/training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private IUnitOfWork uow;


        public TrainingController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Metoda koja vraca sve postojece treninge iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu treninga</returns>
        //[Authorize(Roles = "Operator, Coach")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Training> trainings = uow.Trainings.GetAll();
            return Ok(trainings);
        }

        /// <summary>
        /// Metoda koja vraca treninge za odredjenu salu
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult koji sadrzi listu treninga</returns>
        [HttpGet("{id}")]
        public IActionResult GetByGym(int id)
        {
            List<Training> trainings = uow.Trainings.FindByGym(id);
            return Ok(trainings);
        }

        /// <summary>
        /// Metoda koja kreira novi trening
        /// </summary>
        /// <param name="model">TrainingModel koji sadrzi sve neophodne podatke za kreiranej treninga</param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
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

        /// <summary>
        /// Metoda koja brise trening iz baze
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
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
