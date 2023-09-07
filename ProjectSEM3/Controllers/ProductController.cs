using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
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
        static public int STS_Published = 0;
        static public int STS_Inactive = 1;
        static public int STS_Scheduled = 2;

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
                var products = await _context.Products.Where(e => e.Status == 0).
                Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Price,
                    e.Description,
                    e.Gender,
                    e.OpenSale,
                    e.Status,
                    categoryDetail = new { e.CategoryDetail.Id, e.CategoryDetail.Name, e.CategoryDetail.Category },
                    e.Kindofsport,
                    productColors = e.ProductColors.Select(a => new
                    {
                        a.Id,
                        a.Name,
                        a.ProductId,
                        a.ProductColorImages,
                        productSizes = a.ProductSizes.Select(s => new { s.Id, s.Qty, s.SizeId, s.ProductColorId, s.Size })
                    }),
                }).ToListAsync();
                return Ok(products);
            }
            var product = await _context.Products.
                Include(e => e.CategoryDetail).ThenInclude(c => c.Category).
                Where(e=>e.Id == id && e.Status == 0).
                Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Price,
                    e.Description,
                    e.Gender,
                    e.OpenSale,
                    e.Status,
                    categoryDetail = new { e.CategoryDetail.Id, e.CategoryDetail.Name, e.CategoryDetail.Category },
                    e.Kindofsport,
                    productColors = e.ProductColors.Select(a => new
                    {
                        a.Id,
                        a.Name,
                        a.ProductId,
                        a.ProductColorImages,
                        productSizes = a.ProductSizes.Select(s => new { s.Id, s.Qty, s.SizeId, s.ProductColorId, s.Size })
                    }),
                }).FirstOrDefaultAsync();
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

        [HttpGet,Route("search"),AllowAnonymous]
        async public Task<IActionResult> Search (string search)
        {
            var s = search.ToLower();

            var query = _context.Products.AsQueryable();
            if (!String.IsNullOrEmpty(s))
            {
                var rs = await _context.Products.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Price,
                    e.Description,
                    e.Gender,
                    e.OpenSale,
                    e.Status,
                    categoryDetail = new { e.CategoryDetail.Id, e.CategoryDetail.Name, e.CategoryDetail.Category },
                    e.Kindofsport,
                    productColors = e.ProductColors.Select(a => new
                    {
                        a.Id,
                        a.Name,
                        a.ProductId,
                        a.ProductColorImages,
                        productSizes = a.ProductSizes.Select(s => new { s.Id, s.Qty, s.SizeId, s.ProductColorId, s.Size })
                    }),
                }).Where(e=>e.Name.Contains(s)).Take(5).ToListAsync();
                return Ok(rs);
            }
            return NotFound();
        }

        [HttpGet,Route("Filter"),AllowAnonymous]
        async public Task<IActionResult> Filter (string search)
        {
            var s = _context.Products.AsQueryable();
           s = s.Where(e=>e.Name.ToLower().Contains(search));
           s = s.Where(e => e.CategoryDetail.Name.Equals("Sneakers"));
           s = s.Include(e => e.CategoryDetail);
            var rs = s.ToList();
            return Ok(rs);
        }

        private bool FilterCase(Product p, string search)
        {
            var s = search.ToLower();

            var ctgr_dt = p.CategoryDetail.Name.ToLower().Contains(s);
            var ctgr_dt2 = s.Contains(p.CategoryDetail.Name.ToLower());

            var ctgr = p.CategoryDetail.Category.Name.ToLower().Contains(s);
            var ctgr2 = s.Contains(p.CategoryDetail.Category.Name.ToLower());

            var color = p.ProductColors.Where(c => c.Name.ToLower().Contains(s)).Count() > 0;
            var color2 = p.ProductColors.Where(c => s.Contains(c.Name.ToLower())).Count() > 0;

            var adult = p.Gender == (s.Equals("men") ? 0 : s.Equals("women") ? 1 : 2);
            var adult2 = p.Gender == (s.Contains("men") ? 0 : s.Contains("women") ? 1 : 2);

            var child = p.Gender == ((s.Equals("boy") && p.ProductForChildren.Any()) ? 0 : (s.Equals("girl") && p.ProductForChildren.Any()) ? 1 : 2);
            var child2 = p.Gender == ((s.Contains("boy") && p.ProductForChildren.Any()) ? 0 : (s.Contains("girl") && p.ProductForChildren.Any()) ? 1 : 2);
            var kos = p.Kindofsport.Name.ToLower().Contains(s);
            /*
             - ctgr dt / ctgr / gender
             - ctgr dt / ctgr / color
             - ctgr / gender
             - ctgr / color
             - ctgr dt
             - ctgr
             - gender
             - color
             */
            return (ctgr_dt);
        }
    }
}


