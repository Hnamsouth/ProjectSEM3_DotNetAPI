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
    [Route("api/[controller]")]
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
                var cds = await _context.CategoryDetails.ToListAsync();
                return Ok(cds);
            }
            var cd = await _context.CategoryDetails.FindAsync(id);

            if (cd == null) { return NotFound(); }
            return Ok(cd);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(CategoryDetailDto data)
        {
            if (ModelState.IsValid)
            {
                _context.CategoryDetails.Add(new CategoryDetail { Name = data.Name, CategoryId = data.CategoryId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
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
