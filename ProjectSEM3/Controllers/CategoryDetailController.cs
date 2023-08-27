using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;

namespace ProjectSEM3.Controllers
{
    [Route("api/category-detail")]
    [ApiController]
    public class CategoryDetailController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public CategoryDetailController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var cds = await _context.CategoryDetails.Include(e => e.Category).ToListAsync();
                return Ok(cds);
            }
            var cd = await _context.CategoryDetails.Include(e=>e.Category).Where(c=>c.Id.Equals(id)).FirstOrDefaultAsync();

            if (cd == null) { return NotFound(); }
            return Ok(cd);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(CategoryDetailDto data)
        {
            if (ModelState.IsValid)
            {
                var c = new CategoryDetail { Name = data.Name, CategoryId = data.CategoryId };
                await _context.CategoryDetails.AddAsync(c);
                await _context.SaveChangesAsync();
                return Ok(await _context.CategoryDetails.Include(e => e.Category).Where(d => d.Id.Equals(c.Id)).FirstOrDefaultAsync());
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(CategoryDetail data)
        {
            if (ModelState.IsValid)
            {
                _context.CategoryDetails.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.CategoryDetails.Find(id);
            if (a != null)
            {
                _context.CategoryDetails.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
