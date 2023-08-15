using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Services;

namespace ProjectSEM3.Controllers
{
    [Route("api/discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public DiscountController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var dcs = await _context.Discounts.ToListAsync();
                return Ok(dcs);
            }
            var dc = await _context.Discounts.FindAsync(id);

            if (dc == null) { return NotFound(); }
            return Ok(dc);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(DiscountDto data)
        {
            if (ModelState.IsValid)
            {
                _context.Discounts.Add(new Discount { Coupon = data.Coupon, Description = data.Description, DiscountPercent = data.DiscountPercent, Thumbnail = data.Thumbnail });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(Discount data)
        {
            if (ModelState.IsValid)
            {
                _context.Discounts.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.Discounts.Find(id);
            if (a != null)
            {
                _context.Discounts.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet, Route("upload-demo")]
        async public Task<IActionResult> Upload()
        {
            var rs = await UploadImg.Upload(null, null, null);
            Console.WriteLine(rs);
            return Ok(rs);
        }
        [HttpGet, Route("upload-getImg")]
        async public Task<IActionResult> GetImgFolder()
        {
            var rs = await UploadImg.getImg(null);
            return Ok(rs);
        }
    }
}
