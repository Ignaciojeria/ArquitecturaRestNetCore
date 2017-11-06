using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.IService;
using WebApiNetCore.Model;
using WebApiNetCore.Repository;

namespace WebApiNetCore.ServiceImpl
{
    public class UserService : IUserService
    {
        UserRepository userRepository = PDbContext.GetuUserRepositoryFromDbContext();

        public User findUserbyUserModel(UserModel userModel)
        {
           return userRepository.HttpPostFindUser(userModel);
        }

        public bool HttpPostFindUser(UserModel userModel)
        {
            try {
                userRepository.HttpPostFindUser(userModel);
                return true;
            }
            catch {
                return false;
            }
          
        }
      
    }
}
