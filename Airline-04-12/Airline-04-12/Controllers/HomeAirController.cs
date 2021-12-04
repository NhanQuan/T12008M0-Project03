using Airline_04_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_04_12.Controllers
{
    public class HomeAirController : Controller
    {
        AirlineContext ctx;

        public HomeAirController(AirlineContext ctx)
        {
            this.ctx = ctx;
        }
       
        public async Task<IActionResult> Index()
        {           
            return View(await ctx.Tickets.ToListAsync());
        }
        public async Task<IActionResult> Searchtiket()
        {
            return View(await ctx.Tickets.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Searchtickets(string departureaddress, string arrivalAddress, string time)
        {
            var result = await ctx.Tickets.Where(t => t.DepartureAddress.Contains(departureaddress) && t.ArrivalAddress.Contains(arrivalAddress) && t.DepartureDate.Contains(time)).ToListAsync();
            return View("Index",result);
        }
    }
}
