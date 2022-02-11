using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private IUnitOfWork uow;

        public SelectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Selection> selections = uow.Selections.GetAll();
            return Ok(selections);
        }
       
        [HttpGet("ages")]
        public IActionResult GetAllAges()
        {
            List<SelectionAge> selectionAges = uow.Selections.GetAllAges();
            return Ok(selectionAges);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id)
        {
            Selection s = uow.Selections.FindById(id);
            return Ok(s);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSelection([FromRoute] int id, [FromBody] SelectionModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Selection s = new Selection
            {
                SelectionName = model.SelectionName,

                SelectionAgeID = model.SelectionAgeID
            };

            if(model.AddedPlayers != null && model.AddedPlayers.Count > 0)
            {
                foreach(Player p in model.AddedPlayers)
                {
                    Player player = uow.Players.FindById(p.PlayerID);
                    player.SelectionID = id;
                    uow.Players.Update(player, p.PlayerID);
                }
            }
            if (model.RemovedPlayers != null && model.RemovedPlayers.Count > 0)
            {
                foreach (Player p in model.RemovedPlayers)
                {
                    Player player = uow.Players.FindById(p.PlayerID);
                    player.SelectionID = null;
                    uow.Players.Update(player, p.PlayerID);
                }
            }
            if (model.AddedCoaches != null && model.AddedCoaches.Count> 0)
            {
                foreach (Coach c in model.AddedCoaches)
                {
                    Coach coach = uow.Coaches.FindById(c.UserID);
                    coach.SelectionID = id;
                    uow.Coaches.Update(coach, c.UserID);
                }
            }

            if (model.RemovedCoaches != null && model.RemovedCoaches.Count > 0)
            {
                foreach (Coach c in model.RemovedCoaches)
                {
                    Coach coach = uow.Coaches.FindById(c.UserID);
                    coach.SelectionID = null;
                    uow.Coaches.Update(coach, c.UserID);
                }
            }

            uow.Selections.Update(s, id);
            uow.Commit();

            return Ok();

        }

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

            uow.Selections.Insert(selection);
            uow.Commit();

            return Ok(selection);
        }

      //  [Authorize(Roles = "Operator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSelection(int id)
        {
            Selection selection = uow.Selections.FindById(id);
            if(selection == null)
            {
                return BadRequest();
            }
            uow.Selections.Delete(selection);
            uow.Commit();
            return Ok();
        }
    }
}
