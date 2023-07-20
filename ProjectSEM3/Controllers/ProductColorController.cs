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
    [ApiController]
    [Route("api/[controller]")]
    public class ProductColorController : Controller
    {

        private readonly ProjectSem3Context _context;

        public ProductColorController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet, Route("get")]
        async public Task<IActionResult> Get(int? id)
        {
            var pc = await _context.ProductColors.ToListAsync();
            if (pc == null) return NotFound();
            if (id != null)
            {
                var pcs = await _context.ProductColors.FindAsync(id);
                return Ok(pcs);
            }
            return Ok(pc);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProductColorDto data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductColors.Add(new ProductColor { Img = data.Img, ColorName = data.ColorName, ProductId = data.ProductId }) ;
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);

            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update(ProductColor data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductColors.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var pc = _context.ProductColors.Find(id);
            if (pc != null)
            {
                _context.ProductColors.Remove(pc);
                await _context.SaveChangesAsync();
            }
            return NotFound();
        }

        [HttpGet, Route("upload-demo")]
        async public Task<IActionResult> Upload()
        {
            var up = new UploadImg();
            var rs = await up.Upload(null, null, null);
            Console.WriteLine(rs);
            return Ok(rs);
        }
    }
}

