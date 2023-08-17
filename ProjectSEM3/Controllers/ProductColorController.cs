using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.Entities;

namespace ProjectSEM3.Controllers
{
    [Route("api/product-color")]
    [ApiController]
    public class ProductColorController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public ProductColorController(ProjectSem3Context context)
        {
            _context= context;
        }

        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id != null)
            {
                var pcls = await _context.ProductColors.ToListAsync();
                return Ok(pcls);
            }
            var pcl= await _context.Products.FindAsync(id);
            if(pcl==null) return NotFound();
            return Ok(pcl);
        }

        [HttpPost]
        async public Task<IActionResult> Create(ProductColor data)
        {
            if(ModelState.IsValid)
            {
                await _context.ProductColors.AddAsync(data);
                await _context.SaveChangesAsync();
                return Ok(data);
            }
            return BadRequest();
        }


    }
}
