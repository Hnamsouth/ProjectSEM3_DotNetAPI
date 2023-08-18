using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectSEM3.DTOs;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;
using ProjectSEM3.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSEM3.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProjectSem3Context _context;

        public ProductController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var products = await _context.Products.
                Include(e => e.CategoryDetail).ThenInclude(c => c.Category).
                Include(e => e.Kindofsport).
                Include(e => e.ProductColors).ThenInclude(c => c.ProductColorImages).
                Include(e => e.ProductColors).ThenInclude(i => i.ProductSizes).
                ToListAsync();
                return Ok(products);
            }
            var product = await _context.Products.
                Include(e => e.CategoryDetail).ThenInclude(c => c.Category).
                Include(e => e.Kindofsport).
                Include(e => e.ProductColors).ThenInclude(i => i.ProductColorImages).
                Include(e => e.ProductColors).ThenInclude(i => i.ProductSizes).
                Where(e=>e.Id == id).FirstOrDefaultAsync();
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(ProductFormCreate data)
        {
            
            if (ModelState.IsValid)
            {
                var p = Mapper<ProductFormCreate,Product>.Map(data);
                await _context.Products.AddAsync(p);
                await _context.SaveChangesAsync();

                var rs = await _context.Products.Include(e => e.CategoryDetail).ThenInclude(c => c.Category).
                        Include(e => e.Kindofsport).Where(e => e.Id == p.Id).FirstOrDefaultAsync();
                return Ok(rs);
            }
            
            return BadRequest();
        }

        [HttpPost]
        [Route("image")]
        public IActionResult Index([FromForm] ProductColorCreate FormData)
        {
            try
            {
                //var data = UploadImg.Upload(FormData.Img[0], "Products/color1", "productname", "#PPColor1");
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-image")]
        public IActionResult GetImg()
        {
            try
            {
                var data = UploadImg.getImg("Products/sp6");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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


