using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Services
{

    public class UserService : IUserService
    {
        private readonly IDataAccess _dataAccess;
        public UserService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public User MapUser(UserViewModel userViewModel)
        {
            var hashPassword = ToByteArray(userViewModel.Password);
            var user = new User
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                RoleId = userViewModel.RoleId,
                UserId = userViewModel.UserId,
                UserName = userViewModel.UserName,
                Active = userViewModel.Active,
                HashPassword = hashPassword,
            };

            return user;
        }

        public ReturnType LoginConfirmation(UserViewModel userViewModel)
        {
            var existingUser = _dataAccess.GetUserByUserName(userViewModel.UserName);
            if(existingUser == null)
            {
                return new ReturnType { Message = ReturnMessage.InvalidUser,Status= false };
            }
            var password = System.Text.Encoding.Default.GetString(ToByteArray(userViewModel.Password));
            var exitingPassword = System.Text.Encoding.Default.GetString(existingUser.HashPassword);
            if (exitingPassword == password)
            {
                return new ReturnType { Message = ReturnMessage.LoginSuccessfull,Status = true };
            }
            else
            {
                return new ReturnType { Message = ReturnMessage.InvalidPassword, Status = false };
            }
        }
        public byte[] ToByteArray(string password)
        {
            var mcsp = new MD5CryptoServiceProvider();
            byte[] pass = Encoding.ASCII.GetBytes(password);
            return mcsp.ComputeHash(pass);
        }
    }
}
