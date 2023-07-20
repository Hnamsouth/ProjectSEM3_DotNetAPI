using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSEM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : Controller
    {

        private readonly ProjectSem3Context _context;

        public ProductSizeController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet, Route("get")]
        async public Task<IActionResult> Get(int? id)
        {
            var ps = await _context.ProductSizes.ToListAsync();
            if (ps == null) return NotFound();
            if (id != null)
            {
                var pss = await _context.ProductSizes.FindAsync(id);
                return Ok(pss);
            }
            return Ok(ps);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProductSizeDto data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductSizes.Add(new ProductSize { Qty = data.Qty, ProductColorId = data.ProductColorId , SizeId = data.SizeId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);

            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update(ProductSize data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductSizes.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var ps = _context.ProductSizes.Find(id);
            if (ps != null)
            {
                _context.ProductSizes.Remove(ps);
                await _context.SaveChangesAsync();
            }
            return NotFound();
        }
    }
}

