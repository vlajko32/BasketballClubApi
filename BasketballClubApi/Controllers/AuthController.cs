using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using BasketballClub_Rest.Services;
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
    /// Kontroler koji sluzi za registraciju i prijavljivanje korisnika
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;
        private IUnitOfWork uow;

        public AuthController(IAuthService authService, IUnitOfWork uow)
        {
            this.authService = authService;
            this.uow = uow;
        }

        /// <summary>
        /// Metoda koja sluzi za registraciju korisnika
        /// </summary>
        /// <param name="model">Model sa svim neophodnim podacima o korisniku</param>
        /// <returns>IActionResult koji pokazuje gresku ukoliko postoji, ili status OK ukoliko je zahtev validan</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            AuthData authData = authService.Register(model);

            if (authData.Errors != null)
            {
                return BadRequest(authData.Errors);
            }

           

            return Ok(authData);

        }
        /// <summary>
        /// Metoda koja sluzi za prijavljivanje korisnika
        /// </summary>
        /// <param name="model">Model sa podacima potrebnim za prijavljivanje korisnika</param>
        /// <returns>IActionResult koji pokazuje gresku ukoliko postoji, ili status OK ukoliko je zahtev validan</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthData authData = authService.Login(model);

            if (authData.Errors != null)
            {
                return BadRequest(authData.Errors);
            }



            return Ok(authData);
        }


    }


}
