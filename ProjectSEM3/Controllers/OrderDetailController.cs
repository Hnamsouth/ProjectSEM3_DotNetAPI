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
    public class OrderDetailController : Controller
    {
        private readonly ProjectSem3Context _context;

        public OrderDetailController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet,
            Route("get")]
        async public Task<IActionResult> Get(int? id)
        {

            if (id == null)
            {
                var ods = await _context.OrderDetails.ToListAsync();
                return Ok(ods);
            }
            var od = await _context.OrderDetails.FindAsync(id);
            if (od == null) { return NotFound(); }
            return Ok(od);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(OrderDetailDto data)
        {
            if (ModelState.IsValid)
            {
                _context.OrderDetails.Add(new OrderDetail {Qty = data.Qty, ProductId = data.ProductId, ProductColorId = data.ProductColorId, ProductSizeId = data.ProductSizeId, OrderId = data.OrderId});
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }
    }
}

