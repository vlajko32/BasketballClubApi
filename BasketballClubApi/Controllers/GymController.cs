using BasketballClub_Rest.Domain;
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
    /// Kontroler za rad sa salama
    /// </summary>
    [AllowAnonymous]
    [Route("api/gym")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private GymService gymService;

        public GymController(GymService gymService)
        {
            this.gymService = gymService;
        }
        /// <summary>
        /// Metoda koja vraca sve sale iz baze
        /// </summary>
        /// <returns>IActionResult koji sadrzi listu baza</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Gym> gyms = gymService.GetAll();
            return Ok(gyms);
        }
    }
}
