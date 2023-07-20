using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSEM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : Controller
    {
        private readonly ProjectSem3Context _context;

        public ProductReviewController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet, Route("get")]
        async public Task<IActionResult> Get(int? id)
        {
            var pr = await _context.ProductReviews.ToListAsync();
            if (pr == null) return NotFound();
            if (id != null)
            {
                var prs = await _context.ProductReviews.FindAsync(id);
                return Ok(prs);
            }
            return Ok(pr);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProductReviewDto data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductReviews.Add(new ProductReview { Comment = data.Comment, CreatedAt = data.CreatedAt, Rate = data.Rate, ProductId = data.ProductId, UserId = data.UserId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);

            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update(ProductReview data)
        {
            if (ModelState.IsValid)
            {
                _context.ProductReviews.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var p = _context.ProductReviews.Find(id);
            if (p != null)
            {
                _context.ProductReviews.Remove(p);
                await _context.SaveChangesAsync();
            }
            return NotFound();
        }
    }
}

