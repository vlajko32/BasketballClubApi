using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using BasketballClubApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Controllers
{
    /// <summary>
    /// Kontroler za rad sa selekcijama
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private readonly SelectionService selectionService;

        public SelectionController(SelectionService selectionService)
        {
            this.selectionService = selectionService;
        }
        /// <summary>
        /// Metoda koja sluzi za vracanje svih selekcija iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu selekcija</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Selection> selections = selectionService.GetAll();
            return Ok(selections);
        }

        /// <summary>
        /// Metoda koja sluzi za vracanje svih uzrasta iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu uzrasta</returns>
        [HttpGet("ages")]
        public IActionResult GetAllAges()
        {
            List<SelectionAge> selectionAges = selectionService.GetAllAges();
            return Ok(selectionAges);
        }

        /// <summary>
        /// Metoda koja sluzi za vracanje odredjene selekcije iz baze
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult koji sadrzi trazenu selekciju</returns>
        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id)
        {
            try
            {
                Selection s = selectionService.GetByID(id);
                return Ok(s);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        /// <summary>
        /// Metoda koja sluzi za azuriranje selekcije u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateSelection([FromRoute] int id, [FromBody] SelectionModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Selection updated = selectionService.Update(model, id);
                return Ok(updated);

            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        /// <summary>
        /// Metoda koja sluzi za kreiranje nove selekcije u bazi
        /// </summary>
        /// <param name="model">SelectionModel koji sadrzi neophodne podatke o selekciji</param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
     //   [Authorize(Roles = "Operator")]
        [HttpPost("create")]
        public IActionResult CreateSelection([FromBody] SelectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Selection selection = new Selection
            {
                SelectionName = model.SelectionName,
                SelectionAgeID = model.SelectionAgeID,
              
            };

            try
            {
                Selection s = selectionService.Create(selection);
                return Ok(s);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }

        /// <summary>
        /// Metoda koja sluzi za brisanje selekcije iz baze
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
      //  [Authorize(Roles = "Operator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSelection(int id)
        {
            try
            {
                selectionService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
