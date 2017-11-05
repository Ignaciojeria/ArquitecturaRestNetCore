using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.IService;
using WebApiNetCore.Model;
using WebApiNetCore.Repository;

namespace WebApiNetCore.ServiceImpl
{
    public class UserService : IUserService
    {
        UserRepository userRepository = PDbContext.GetuUserRepositoryFromDbContext();

        public bool HttpPostFindUser(UserModel userModel)
        {
           return userRepository.HttpPostFindUser( userModel);    
        }
    }
}
