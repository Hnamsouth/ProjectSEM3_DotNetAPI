using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSEM3.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public CategoryController(ProjectSem3Context context)
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
                var categories = await _context.Categories.ToListAsync();
                return Ok(categories);
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(CategoryDto data)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(new Category { Name = data.Name });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}",data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        async public Task<IActionResult> Update(Category data)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var c = _context.Categories.Find(id);
            if(c != null)
            {
                _context.Categories.Remove(c);
               await  _context.SaveChangesAsync();
            }
            return NotFound();
        }

        [HttpGet,Route("upload-demo")]
        async public Task<IActionResult> Upload()
        {
            var up = new UploadImg();
            var rs = await up.Upload(null,null,null);
            Console.WriteLine(rs);
            return Ok(rs);
        }
    }
}
