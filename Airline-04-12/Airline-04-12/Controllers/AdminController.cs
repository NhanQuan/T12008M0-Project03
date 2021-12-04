using Airline_04_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_04_12.Controllers
{

    public class AdminController : Controller
    {
        AirlineContext ctx;

        public AdminController(AirlineContext ctx)
        {
            this.ctx = ctx;
        }


        [Route("Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return View("BadRequest");
            }
            Account acc = await ctx.Accounts.SingleOrDefaultAsync(a => a.Username == username);
            if (acc != null && acc.Password == password)
            {
                if(acc.Role == 0)
                {
                    return View("Admin_login");
                }
                else
                {
                    return View("User");
                }
                
            }
            else
            {
                ViewData["Error"] = "Invalid Login";
                return View("Admin");
            }
          
        }
    }

}
