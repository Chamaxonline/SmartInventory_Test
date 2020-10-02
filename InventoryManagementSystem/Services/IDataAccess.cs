using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Services
{
    public interface IDataAccess
    {
        List<UserDetail> GetAllUsers();
        User GetUserByUserName(string userName);
    }
}
