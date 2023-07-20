using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSEM3.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProjectSem3Context _context;

        public OrderController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet,
            Route("get")]
        async public Task<IActionResult> Get(int? id)
        {

            if (id == null)
            {
                var orders = await _context.Orders.ToListAsync();
                return Ok(orders);
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(OrderDto data)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(new Order { Date = data.Date, Status = data.Status, ShipCode = data.ShipCode, UserId = data.UserId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }
    }
}

