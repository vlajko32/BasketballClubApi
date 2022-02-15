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
    /// Kontroler za rad sa igracima
    /// </summary>
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private PlayerService playerService;

        public PlayerController(PlayerService playerService)
        {
            this.playerService = playerService;
        }
        /// <summary>
        /// Metoda koja sluzi za kreiranje novog igraca
        /// </summary>
        /// <param name="model">Model koji sadrzi sve potrebne podatke o igracu</param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
        //[Authorize(Roles="Administrator")]
        [HttpPost("create")]
        public IActionResult CreatePlayer([FromBody] PlayerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Player player = new Player
            {
                Name = model.Name,
                Surname = model.Surname,
                SelectionID = model.SelectionID,
                BirthDate = model.BirthDate,
                Height = model.Height,
                Weight = model.Weight
            };
            if(player.SelectionID==0)
            {
                player.SelectionID = null;
            }

            try
            {
                Player p = playerService.Create(player);
                return Ok(p);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }


        /// <summary>
        /// Metoda koja sluzi za azuriranje igraca u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>

        // [Authorize(Roles = "Operator, Coach")]
        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePlayer([FromRoute] int id, [FromBody] PlayerModel model)
        {
            Player player = new Player
            {
                SelectionID = model.SelectionID,
                Weight = model.Weight,
                Height = model.Height
            };

            try
            {
                Player p = playerService.Update(player, id);
                return Ok(p);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Metoda koja sluzi za brisanje igraca iz baze
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult Ok ako je operacija uspesno obavljena, ili gresku ukoliko nije</returns>
        //[Authorize(Roles = "Operator")]
        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                playerService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Metoda koja sluzi za vracanje svih igraca iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu igraca</returns>
        //[Authorize(Roles = "Operator, Coach")]
        [HttpGet]
       public IActionResult GetAll()
        {
            List<Player> players = playerService.GetAll();
            return Ok(players);
        }


        /// <summary>
        /// Metoda koja sluzi za vracanje igraca sa odredjenim kriterijumom iz baze
        /// </summary>
        /// <param name="search"></param>
        /// <returns>IActionResult koji sadrzi listu igraca koji odgovaraju datom zahtevu</returns>
        [HttpGet("{search}")]
        public IActionResult GetByCriteria(string search)
        {
            List<Player> players = playerService.FindByString(search);
            return Ok(players);
        }

        /// <summary>
        /// Metoda koja sluzi za vracanje iz baze igraca koji ne nastupaju ni za jednu selekciju
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu igraca bez selekcije</returns>
       // [Authorize(Roles = "Operator, Coach")]
        [HttpGet("withoutSelection")]
        public IActionResult GetWithoutSelection()
        {
            List<Player> players = playerService.FindWithoutSelection();
            return Ok(players);
        }
    }
}
