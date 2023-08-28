using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var categories = await _context.Categories.Include(e => e.CategoryDetails).ToListAsync();
                return Ok(categories);
            }
            var category = await _context.Categories.Include(e=>e.CategoryDetails).Where(e=>e.Id.Equals(id)).FirstOrDefaultAsync();
            
            if (category == null) { return NotFound(); }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost,Route("create")]
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
        [HttpPut, Route("update")]
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
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var c = _context.Categories.Find(id);
            if(c != null)
            {
                _context.Categories.Remove(c);
               await  _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost,Route("upload-demo")]
        async public Task<IActionResult> Upload([FromForm]IFormFile img)
        {
            
            var rs = await UploadImg.Upload(img, "Product","SP1","#PPSP1");
            Console.WriteLine(rs);
            return Ok(rs);
        }
        [HttpGet, Route("upload-getImg")]
        async public Task<IActionResult> GetImgFolder()
        {
            var rs = await UploadImg.getImg(null);
            return Ok(rs);
        }
    }
}
//aaaa