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
                Select(e => new
                {
                    e.Id,e.Name,e.Price,e.Description,e.Gender,e.OpenSale,e.Status,
                    categoryDetail = new
                    {
                        e.CategoryDetail.Id,e.CategoryDetail.Name,e.CategoryDetail.Category
                    },
                    e.Kindofsport,
                    productColors = e.ProductColors.Select(a => new
                    {
                        a.Id,a.Name, a.ProductId,a.ProductColorImages,
                        productSizes = a.ProductSizes.Select(s => new
                        {
                            s.Id,s.Qty,s.SizeId,s.ProductColorId,s.Size
                        })
                    }),
                }).Where(e => e.Status == 0).ToListAsync();
                return Ok(products);
            }
            var product = await _context.Products.
                Include(e => e.CategoryDetail).ThenInclude(c => c.Category).Select(e => new
                {
                    e.Id,e.Name,e.Price,e.Description,e.Gender,e.OpenSale,e.Status,
                    categoryDetail = new
                    {
                        e.CategoryDetail.Id,e.CategoryDetail.Name,e.CategoryDetail.Category
                    },
                    e.Kindofsport,
                    productColors = e.ProductColors.Select(a => new
                    {
                        a.Id,a.Name, a.ProductId,a.ProductColorImages,
                        productSizes = a.ProductSizes.Select(s => new
                        {
                            s.Id,s.Qty,s.SizeId,s.ProductColorId,s.Size
                        })
                    }),
                }).
                Where(e=>e.Id == id && e.Status == 0).FirstOrDefaultAsync();
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
        async public Task<IActionResult> Update(ProductFormCreate data)
        {
            if (ModelState.IsValid)
            {
                var p = Mapper<ProductFormCreate, Product>.Map(data);
                _context.Products.Update(p);
                await _context.SaveChangesAsync();

               var rs = await _context.Products.Include(e => e.CategoryDetail).ThenInclude(c => c.Category).
                        Include(e => e.Kindofsport).Where(e => e.Id == p.Id).FirstOrDefaultAsync();
                return Ok(rs);
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


        [HttpGet,Route("nav-data")]
        async public Task<IActionResult> NavData()
        {
            var c_male =  _context.Products.Where(e=>e.Gender==0).Select(e => e.CategoryDetailId);
            var c_female =  _context.Products.Where(e=>e.Gender==1).Select(e => e.CategoryDetailId);
            var c_kid =  _context.Products.Where(e=>e.Gender==2).Select(e => e.CategoryDetailId);

            var data_male = _context.Categories.Select(e => new
            {
                e.Id,
                e.Name,
                data = e.CategoryDetails.Where(a=> c_male.Contains(a.Id)),
            });
            var data_female = _context.Categories.Select(e => new
            {
                e.Id,
                e.Name,
                data = e.CategoryDetails.Where(a=> c_female.Contains(a.Id)),
            });
            var data_kid = _context.Categories.Select(e => new
            {
                e.Id,
                e.Name,
                data = e.CategoryDetails.Where(a=> c_kid.Contains(a.Id)),
            });

            var  data =new object[] { 
                new {Title="WOMEN",data= data_female },
                new {Title="MAN",data= data_male }, 
                new {Title="KID",data= data_kid } };

            return Ok(data);
        }

        [HttpGet,Route("search-by")]
        async public Task<IActionResult> SearchBy([FromQuery] int gender, [FromQuery] int categoryDetailId)
        {
            var product = await _context.Products.
                Where(e => e.Gender==gender && e.CategoryDetailId==categoryDetailId).
                Select(e => new
                {
                    e.Id,e.Name,e.Price,e.Description,e.Gender,e.OpenSale,e.Status,
                    categoryDetail = new
                    {
                        e.CategoryDetail.Id,e.CategoryDetail.Name,e.CategoryDetail.Category
                    },
                    e.Kindofsport,
                    productColors = e.ProductColors.Select(a => new
                    {
                        a.Id,a.Name,a.ProductId,a.ProductColorImages,
                        productSizes = a.ProductSizes.Select(s => new
                        {
                            s.Id,s.Qty,s.SizeId,s.ProductColorId,s.Size
                        })
                    }),

                }).
                ToListAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}


