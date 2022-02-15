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
    /// Kontroler za rad sa igracima
    /// </summary>
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private IUnitOfWork uow;

        public PlayerController(IUnitOfWork uow)
        {
            this.uow = uow;
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

            uow.Players.Insert(player);
            uow.Commit();

            return Ok();

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
            Player player = uow.Players.FindById(id);
            player.SelectionID = model.SelectionID;
            player.Height = model.Height;
            player.Weight = model.Weight;
            uow.Players.Update(player, id);
            uow.Commit();

            return Ok();
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
            Player player = uow.Players.FindById(id);
            if(player == null)
            {
                return BadRequest();
            }
            uow.Players.Delete(player);
            uow.Commit();
            return Ok();
        }

        /// <summary>
        /// Metoda koja sluzi za vracanje svih igraca iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu igraca</returns>
        //[Authorize(Roles = "Operator, Coach")]
        [HttpGet]
       public IActionResult GetAll()
        {
            List<Player> players = uow.Players.GetAll();
            return Ok(players);
        }


        /// <summary>
        /// Metoda koja sluzi za vracanje igraca sa odredjenim kriterijumom iz baze
        /// </summary>
        /// <param name="search"></param>
        /// <returns>IActionResult koji sadrzi listu igraca koji odgovaraju datom zahtevu</returns>
        [HttpGet("{search}")]
        public IActionResult GetAll(string search)
        {
            List<Player> players = uow.Players.FindByString(search);
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
            List<Player> players = uow.Players.FindWithoutSelection();
            return Ok(players);
        }
    }
}
