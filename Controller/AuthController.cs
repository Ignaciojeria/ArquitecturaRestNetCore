using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore.IService;
using WebApiNetCore.Entity;
using WebApiNetCore.Model;

namespace WebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    public class AuthController: Controller
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService) {
            this.userService = userService;
        }

        [HttpPost]
        public bool Post([FromBody]UserModel userModel)
        {
            return userService.HttpPostFindUser(userModel);
        }

    }
}
