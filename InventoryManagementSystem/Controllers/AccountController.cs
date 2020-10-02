using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Utilities;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext _userContext;
        private readonly IUserService _userService;
        public AccountController(UserContext userContext, IUserService userService)
        {
            _userContext = userContext;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public ReturnType LoginTry(UserViewModel userViewModel)
        {
            if (userViewModel.UserName !=null && userViewModel.Password !=null)
            {
                var message = _userService.LoginConfirmation(userViewModel);
                return message;
            }
            else
            {
                return new ReturnType { Message = ReturnMessage.InvalidLogin,Status=false };
            }
        }
    }
}