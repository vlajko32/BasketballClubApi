using BasketballClub_Rest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Services
{
    public interface IAuthService
    {
        AuthData Register(RegisterModel model);
        AuthData Login(LoginModel model);
    }
}
