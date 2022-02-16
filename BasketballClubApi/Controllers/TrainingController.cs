using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using BasketballClubApi.Services;
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
        private TrainingService trainingService;


        public TrainingController(TrainingService trainingService)
        {
            this.trainingService = trainingService;
        }

        /// <summary>
        /// Metoda koja vraca sve postojece treninge iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu treninga</returns>
        //[Authorize(Roles = "Operator, Coach")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Training> trainings = trainingService.GetAll();
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
            try
            {
                List<Training> trainings = trainingService.GetByGym(id);
                return Ok(trainings);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

            try
            {
                Training t = trainingService.Create(training);
                

                return Ok(t);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

       
    }
}
