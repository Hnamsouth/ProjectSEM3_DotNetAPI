using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using System.Linq;

namespace ProjectSEM3.Controllers
{
    [Route("api/sort")]
    [ApiController]
    public class SortDataController : ControllerBase
    {
        private readonly ProjectSem3Context _context;
        public SortDataController(ProjectSem3Context context)
        {
            _context = context;
        }


        [HttpGet, Route("bar-data")]
        async public Task<IActionResult> GetFor()
        {
            var rs = from Category in _context.Categories
                          join Product in _context.Products
                          on Category.Id equals Product.CategoryDetail.Category.Id into result
                          select new
                          {
                              Category.Id,
                              Category.Name,
                              Count = result.Count()
                          };
            rs = rs.OrderByDescending(e => e.Count);

            var rs2 = from CategoryDetail in _context.CategoryDetails
                     join Product in _context.Products
                     on CategoryDetail.Id equals Product.CategoryDetail.Id into result
                     select new
                     {
                         CategoryDetail.Id,
                         CategoryDetail.Name,
                         Count = result.Count()
                     };
            rs2 = rs2.OrderByDescending(e => e.Count);

            return Ok(new {categories=rs.Take(6).ToList(),categoryDetail=rs2.Take(6).ToList() });
        }
        [HttpGet,Route("sort-by")]
        async public Task<IActionResult> SortBy(int key)
        {
            var rs = _context.Products.AsQueryable();
            if (key.Equals(0))
            {
                // 1: price low - high
                rs = rs.OrderBy(e => e.Price);
            }else if (key.Equals(1))
            {
                // 2: newest
                rs = rs.Where(e => e.Status == ProductController.STS_Published).OrderByDescending(e => e.Id);
            }
            else if (key.Equals(2))
            {
                // 3: top seller

                //rs = rs.OrderByDescending(e => e.)
            }
            else if (key.Equals(3))
            {
                // 4: price high - low
                rs = rs.OrderByDescending(e => e.Price);
            }

            var result = rs.
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
                }).ToList();
            return Ok(result);
        }


        [HttpPost,Route("custom")]
        async public Task<IActionResult> Custom (SortData data)
        {
            var rs = _context.Products.AsQueryable();
            if (data.CtgrSelect.Any() && data.CtgrDetailSelect.Any())
            {
                rs = rs.Where(e => data.CtgrSelect.Contains(e.CategoryDetail.Category.Id.ToString()) &&data.CtgrDetailSelect.Contains(e.CategoryDetail.Id.ToString()));
            }else if (data.CtgrSelect.Any())
            {
                rs = rs.Where(e => data.CtgrSelect.Contains(e.CategoryDetail.Category.Id.ToString()));
            }else if (data.CtgrDetailSelect.Any())
            {
                rs = rs.Where(e => data.CtgrDetailSelect.Contains(e.CategoryDetail.Id.ToString()));
            }

            var result = rs.
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
                }).ToList();
            return Ok(result);
        }
    }
}
