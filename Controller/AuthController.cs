using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore.IService;
using WebApiNetCore.Entity;
using WebApiNetCore.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        readonly IAuthService authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public string Post([FromBody]UserModel userModel)
        {

            if (userService.HttpPostFindUser(userModel) == false)
                return "El usuario no existe";
            var token = authService.GenerateTokenForUser(userService.findUserbyUserModel(userModel));
            return token;
        }
       // [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
          //  return "Quiero interceptar el subject del token que viene en la cabecera Autorization de la solicitud http";
   //Retorna el token de quien hace la solicitud! Si no puedes interceptar los claims calculalos con una clase auxiliar xD!
             return Request.Headers["Authorization"];
        }
    }
}
