using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.Model;

namespace WebApiNetCore.Repository
{
    public class UserRepository
    {
        private List<User> usuarios;

        private static UserRepository userRepository = new UserRepository();

        private UserRepository() {
            usuarios = new List<User>();
            mock();
        }

        private void mock() {
            usuarios.Add(new User() { id = 1, Username = "admin", Password = "admin" });
            usuarios.Add(new User() {id=2,Username="user", Password="user" });
            usuarios.Add(new User() {id=3,Username="invited",Password="invited"});
        }

        public bool HttpPostFindUser(UserModel userModel) {
            User user=usuarios.First(i => i.Username == userModel.username && i.Password==userModel.password);

            if (user == null)
                return false;

            else
                return true;
        }

        public static UserRepository getInstance() {
            return userRepository;
        }



    }
}
