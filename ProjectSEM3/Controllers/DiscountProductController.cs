using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;

namespace ProjectSEM3.Controllers
{
    [Route("api/discountProduct")]
    [ApiController]
    public class DiscountProductController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public DiscountProductController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var dpcs = await _context.DiscountProducts.ToListAsync();
                return Ok(dpcs);
            }
            var dpc = await _context.DiscountProducts.FindAsync(id);

            if (dpc == null) { return NotFound(); }
            return Ok(dpc);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(DiscountProductDto data)
        {
            if (ModelState.IsValid)
            {
                _context.DiscountProducts.Add(new DiscountProduct { ProductId = data.ProductId, DiscountId = data.DiscountId, StartDate = data.StartDate, EndDate = data.EndDate });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(DiscountProduct data)
        {
            if (ModelState.IsValid)
            {
                _context.DiscountProducts.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.DiscountProducts.Find(id);
            if (a != null)
            {
                _context.DiscountProducts.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
