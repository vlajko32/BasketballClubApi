using BasketballClub_Rest.Domain;
using BasketballClub_Rest.DTO;
using BasketballClub_Rest.Repository.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BasketballClub_Rest.Services
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork uow;

        private string jwtSecret;
        private int jwtLifespan;

        public AuthService(IUnitOfWork uow, string jwtSecret, int jwtLifespan)
        {
            this.uow = uow;
            this.jwtSecret = jwtSecret;
            this.jwtLifespan = jwtLifespan;
        }

        public AuthData Login(LoginModel model)
        {
            User user = uow.Users.FindOne(us => us.Username == model.Username);
            if (user == null)
            {
                return new AuthData { Errors = new[] { "Username not found." } };
            }

            if (!VerifyPassword(model.Password, user.Password))
            {
                return new AuthData { Errors = new[] { "Wrong password." } };
            }
            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                User = user
            };


        }

        public AuthData Register(RegisterModel model)
        {
            if (uow.Users.FindOne(us => us.Username == model.Username) != null)
            {
                return new AuthData { Errors = new[] { "Username already taken!" } };
            }
            List<Code> codes = uow.Users.GetCodes();
            if (!codes.Any(c => c.Value == Int32.Parse(model.Code)))
            {
                return new AuthData { Errors = new[] { "Wrong registration code." } };
            }

            if (model.Role == "Coach")
            {
                Coach coach = new Coach
                {
                    Role = model.Role,
                    Username = model.Username,
                    Password = HashPassword(model.Password),
                    Name = model.Name,
                    Surname = model.Surname,
                    YearsOfExperience = model.YearsOfExperience,
                    SelectionID = model.SelectionID,

                };
                if(coach.SelectionID == 0)
                {
                    coach.SelectionID = null;
                }
                uow.Coaches.Insert(coach);
                uow.Commit();

                return new AuthData { Coach = coach };
            }
            else if(model.Role =="Operator")
            {
                Administrator administrator = new Administrator
                {
                    Role = model.Role,
                    Username = model.Username,
                    Password = HashPassword(model.Password),
                    Name = model.Name,
                    Surname = model.Surname
                };

                uow.Administrators.Insert(administrator);
                uow.Commit();

                return new AuthData { Administrator = administrator };
            }
            else
            {
                return new AuthData { Errors = new[] { "Role must be Coach or Administrator" } };
            }
            

        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}


