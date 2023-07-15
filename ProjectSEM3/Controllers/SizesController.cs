using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;

namespace ProjectSEM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public SizesController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet,Route("get")]
        async public Task<IActionResult> Get(int? id)
        {
            var s = await _context.Sizes.ToListAsync();
            if (s==null) return NotFound();
            if (id != null)
            {
                var ss = await _context.Sizes.FindAsync(id);
                return Ok(ss);
            }
            return Ok(s);
        }

        [HttpPost]
        async public Task<IActionResult> Create(SizeDto data)
        {
            if(ModelState.IsValid) {
                _context.Sizes.Add(new Size { Name=data.Name});
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);

            }
            return BadRequest();
        }

      


    }
}
