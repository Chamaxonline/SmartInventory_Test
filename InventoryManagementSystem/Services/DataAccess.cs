using Dapper;
using InventoryManagementSystem.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Services
{
    public  class DataAccess :IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public string GetDbConncetionString()
        {
            return _configuration.GetConnectionString("StockManagement");
        }
        public List<UserDetail> GetAllUsers()
        {
            var userDetailList = new List<UserDetail>();
            string connString = GetDbConncetionString();

            using (IDbConnection db = new SqlConnection(connString))
            {

                userDetailList = db.Query<UserDetail>("SELECT U.UserId,U.FirstName,U.LastName,U.UserName,U.RoleId,R.RoleName,CASE WHEN u.Active = 1 THEN 'Active' ELSE 'Inactive' END AS Active  FROM [Users] AS U INNER JOIN Roles AS R ON R.RoleId = U.RoleId").ToList();
            }
            return userDetailList;
        }

        public User GetUserByUserName(string userName)
        {
            string connString = GetDbConncetionString();
            var user = new User();
            using (IDbConnection db = new SqlConnection(connString))
            {
                user = db.Query<User>("SELECT UserId,FirstName,LastName,UserName,HashPassword,RoleId,Active FROM Users WHERE UserName ='" + userName + "'").FirstOrDefault();
            }
            return user;
        }
    }
}
