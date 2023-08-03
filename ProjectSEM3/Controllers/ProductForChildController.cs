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
    [Route("api/product-for-child")]
    [ApiController]
    public class ProductForChildController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public ProductForChildController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var pc = await _context.ProductForChildren.ToListAsync();
                return Ok(pc);
            }
            var pcs = await _context.ProductForChildren.FindAsync(id);

            if (pcs == null) { return NotFound(); }
            return Ok(pcs);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(ProductForChildDto data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductForChildren.Add(new ProductForChild {MinAge = data.MinAge, MaxAge = data.MaxAge, ProductId = data.ProductId});
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(ProductForChild data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductForChildren.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.ProductForChildren.Find(id);
            if (a != null)
            {
                _context.ProductForChildren.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
