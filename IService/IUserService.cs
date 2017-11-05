using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Model;

namespace WebApiNetCore.IService
{
    public interface IUserService
    {
        bool HttpPostFindUser(UserModel userModel);
    }
}
