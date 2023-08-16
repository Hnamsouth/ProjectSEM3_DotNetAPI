using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                /*
                var products = await _context.Products.Select(p => new {
                    Id=p.Id,
                    Name=p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ColorName = p.ColorName,
                    Gender = p.Gender,
                    Img = p.Img,
                    OpenSale = p.OpenSale,
                    Status = p.Status,
                    CategoryId = p.CategoryId,
                    CategoryDetailId = p.CategoryDetailId,
                    KindofsportId = p.KindofsportId,
                    categoryDetail = new
                    {
                        id = p.CategoryDetail.Id,
                        name = p.CategoryDetail.Name,
                    },
                    Category = new
                    {
                        id = p.CategoryDetail.CategoryId,
                        name = p.CategoryDetail.Category.Name
                    },
                    kindofsport = new
                    {
                        id=p.KindofsportId,
                        name=p.Kindofsport.Name
                    }
                }).ToListAsync();
                */
                /*
                var products= await _context.Products.Include(e => e.Category).Include(e => e.CategoryDetail).Include(e => e.Kindofsport).ToListAsync();
                List<ProductDemo> pl = Mapper<Product, ProductDemo>.MapList(products);*/
                return Ok();
            }
            var product = await _context.Products.Include(e => e.Category).Include(e => e.CategoryDetail).Include(e => e.Kindofsport).Where(e=>e.Id == id).FirstOrDefaultAsync();
            if (product == null) { return NotFound(); }
            //ProductDemo pd = Mapper<Product, ProductDemo>.Map(product);
            return Ok(product);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create([FromForm]ProductFormCreate data)
        {
            
            if (ModelState.IsValid)
            {
                var p = new Product
                {
                    Name = data.Name,
                    Price = data.Price,
                    Description = data.Description,
                    CategoryId = data.CategoryId,
                    KindofsportId = data.KindofsportId,
                    CategoryDetailId = data.CategoryDetailId,
                    Gender = data.Gender,
                    OpenSale = data.OpenSale,
                    Status = data.Status,
                };
                await _context.Products.AddAsync(p);
                await _context.SaveChangesAsync();

                /*
                var pls = new List<CdnItem>();
                var index = 0;
                foreach(var file in data.Img)
                {
                    pls.Add(await UploadImg.Upload(file, "Products/sp"+p.Id, (data.Name + index).Trim(), "#PP" + data.Name.Trim()));
                    index++;
                }
                p.Img = "Products/sp" + p.Id;
                _context.Products.Update(p);
                await _context.SaveChangesAsync();
                */
                return Ok(await _context.Products.Include(e => e.Category).Include(e => e.CategoryDetail).Include(e => e.Kindofsport).Where(e => e.Id == p.Id).FirstOrDefaultAsync());
            }
            
            return BadRequest();
        }

        [HttpPost]
        [Route("image")]
        public IActionResult Index([FromForm]ProductDemo image)
        {
            if (ModelState.IsValid)
            {
                return Ok(image);
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


