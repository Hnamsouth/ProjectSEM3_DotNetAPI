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

namespace ProjectSEM3.Controllersoucher
{
    [Route("api/voucher")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public VoucherController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var vs = await _context.Vouchers.ToListAsync();
                return Ok(vs);
            }
            var v = await _context.Vouchers.FindAsync(id);

            if (v == null) { return NotFound(); }
            return Ok(v);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(VoucherDto data)
        {
            if (ModelState.IsValid)
            {
                _context.Vouchers.Add(new Voucher { Coupon = data.Coupon, Description = data.Description, DiscountPercent = data.DiscountPercent, DiscountFlat = data.DiscountFlat, Thumbnail = data.Thumbnail, EndDate = data.EndDate, StartDate = data.StartDate });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(Voucher data)
        {
            if (ModelState.IsValid)
            {
                _context.Vouchers.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.Vouchers.Find(id);
            if (a != null)
            {
                _context.Vouchers.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
        [HttpGet, Route("upload-getImg")]
        async public Task<IActionResult> GetImgFolder()
        {
            var rs = await UploadImg.getImg(null);
            return Ok(rs);
        }
    }
}
