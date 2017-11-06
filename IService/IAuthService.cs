using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.Model;

namespace WebApiNetCore.IService
{
    public interface IAuthService
    {
        string GenerateTokenForUser(User userModel);
        string getClaimsFromToken(string token);
    }
}
