using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleContext _context;

        public RoleController(RoleContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllRoles()
        {
            var productList = await _context.Roles.ToListAsync();
            return Json(productList);
        }
    }
}