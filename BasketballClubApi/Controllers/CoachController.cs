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
    /// Kontroler koji sluzi za pozivanje operacija nad objektom Coach
    /// </summary>
    [Route("api/coach")]
    [ApiController]
  //  [Authorize(Roles = "Operator, Coach")]
    public class CoachController : ControllerBase
    {
        private CoachService coachService;

        public CoachController(CoachService coachService)
        {
            this.coachService = coachService;
        }

       

        
       // [Authorize(Roles = "Operator, Coach")]
       /// <summary>
       /// Metoda koja sluzi za vracanje svih objekata Coach iz baze
       /// </summary>
       /// <returns>IActionResult koji sadrzi listu trenera</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Coach> coaches = coachService.GetAll();
            return Ok(coaches);
        }
       // [Authorize(Roles = "Operator, Coach")]
       /// <summary>
       /// Metoda koja sluzi za vracanje iz baze trenera sa datom sifrom
       /// </summary>
       /// <param name="id"></param>
       /// <returns>IActionResult sa trenerom</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                Coach coach = coachService.GetByID(id);
                return Ok(coach);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Metoda koja sluzi za vracanje iz baze trenera koji ne treniraju nijednu selekciju
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu trenera</returns>
       // [Authorize(Roles = "Operator")]
        [HttpGet("withoutSelection")]
        public IActionResult GetWithoutSelection()
        {
            List<Coach> coaches = coachService.GetWithoutSelection();
            return Ok(coaches);
        }
        /// <summary>
        /// Metoda koja sluzi za brisanje trenera iz baze
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
      //  [Authorize(Roles = "Operator")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                coachService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

      //  [Authorize(Roles = "Operator")]

        /// <summary>
        /// Metoda koja sluzi za azuriranje trenera u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCoach([FromRoute] int id, [FromBody] CoachModel model)
        {
            try
            {
                Coach c = coachService.Update(model, id);
                return Ok(c);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

      
    }
}
