using BasketballClub_Rest.Domain;
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
    [AllowAnonymous]
    [Route("api/gym")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private IUnitOfWork uow;

        public GymController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Gym> gyms = uow.Gyms.GetAll();
            return Ok(gyms);
        }
    }
}
