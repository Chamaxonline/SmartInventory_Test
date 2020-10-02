using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Utilities;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;
        private readonly IUserService _userService;
        private readonly IDataAccess _dataAccess;

        public UserController(UserContext context, IUserService userService,IDataAccess dataAccess)
        {
            _context = context;
            _userService = userService;
            _dataAccess = dataAccess;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ReturnType> Create(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userService.MapUser(userViewModel);
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                }
                var result = new ReturnType { Message = ReturnMessage.CreatesSuccessfully };
                return result;
            }
            catch (Exception ex)
            {

                var result = new ReturnType { Message = ex.Message };
                return result;
            }

        }

        [HttpGet]
        public List<UserDetail> GetAllUsers()
        {
            var userDetail = _dataAccess.GetAllUsers();
            
            return userDetail;
        }
    }
}