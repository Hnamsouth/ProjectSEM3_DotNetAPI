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
    public class ProductController : Controller
    {

        private readonly ProjectSem3Context _context;

        public ProductController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet,
           Route("get")]
        async public Task<IActionResult> Get(int? id)
        {

            if (id == null)
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(ProductDto data)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(new Product { Name = data.Name, Price = data.Price, Description = data.Description, CategoryId = data.CategoryId});
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update(Product data)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var p = _context.Products.Find(id);
            if (p != null)
            {
                _context.Products.Remove(p);
                await _context.SaveChangesAsync();
            }
            return NotFound();
        }
    }
}


