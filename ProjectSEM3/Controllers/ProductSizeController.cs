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
    [Route("api/product-size")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {

        private readonly ProjectSem3Context _context;

        public ProductSizeController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            var ps = await _context.ProductSizes.Include(e => e.Size).ToListAsync();
            if (ps == null) return NotFound();
            if (id != null)
            {
                var pss = await _context.ProductSizes.Include(e=>e.Size).Where(e=>e.ProductColorId==id).ToListAsync();
                return Ok(pss);
            }
            return Ok(ps);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProductSizeDto data)
        {
            if (ModelState.IsValid)
            {
                var ps = new ProductSize { Qty = data.Qty, SizeId = data.SizeId, ProductColorId = data.ProductColorId };
                await _context.ProductSizes.AddAsync(ps);
                await _context.SaveChangesAsync();
                return Ok(await _context.ProductSizes.Include(e=>e.Size).Where(e=>e.Id==ps.Id).FirstOrDefaultAsync());

            }
            return BadRequest();
        }

        [HttpPut]
        async public Task<IActionResult> Update(ProductSize data)
        {
            if (ModelState.IsValid)
            {
                var ps = await _context.ProductSizes.FindAsync(data.Id);
                if(ps == null) return NotFound();
                ps.Qty = data.Qty;
                ps.SizeId = data.SizeId;
                ps.ProductColorId = data.ProductColorId;
                _context.ProductSizes.Update(ps);
                await _context.SaveChangesAsync();
                return Ok(await _context.ProductSizes.Include(e => e.Size).Where(e => e.Id==ps.Id).FirstOrDefaultAsync());
            }
            return BadRequest();
        }

        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var ps = _context.ProductSizes.Find(id);
            if (ps != null)
            {
                _context.ProductSizes.Remove(ps);
                await _context.SaveChangesAsync();
            }
            return NotFound();
        }

        [HttpGet,Route("add-size")]
        async public Task<IActionResult> AddSize()
        {
            var pcl = await _context.ProductColors.Where(e => e.ProductId > 12).ToListAsync();
            var size = await _context.Sizes.Where(e=>e.Type==true).ToListAsync();
            Random random= new Random();
            pcl.ForEach(p =>
            {
                size.ForEach(async s =>
                {
                    if (random.Next(1, 7) != s.Id)
                    {
                        var ps = new ProductSize { Qty = random.Next(3, 50), SizeId = s.Id, ProductColorId = p.Id };
                        await _context.ProductSizes.AddAsync(ps);
                    }
                });
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

