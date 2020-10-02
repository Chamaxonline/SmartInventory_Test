using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Utilities;

namespace InventoryManagementSystem.Services
{
    public interface IUserService
    {
        User MapUser(UserViewModel userViewModel);
        ReturnType LoginConfirmation(UserViewModel userViewModel);
    }
}
