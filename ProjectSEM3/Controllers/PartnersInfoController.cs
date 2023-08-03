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
    [Route("api/partners-info")]
    [ApiController]
    public class PartnersInfoController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public PartnersInfoController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var pnis = await _context.PartnersInfos.ToListAsync();
                return Ok(pnis);
            }
            var pni = await _context.PartnersInfos.FindAsync(id);

            if (pni == null) { return NotFound(); }
            return Ok(pni);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(PartnersInfoDto data)
        {
            if (ModelState.IsValid)
            {
                _context.PartnersInfos.Add(new PartnersInfo { Phone = data.Phone, CompanyName = data.CompanyName, Address = data.Address, Img = data.Img, PartnersId = data.PartnersId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(PartnersInfo data)
        {
            if (ModelState.IsValid)
            {
                _context.PartnersInfos.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.PartnersInfos.Find(id);
            if (a != null)
            {
                _context.PartnersInfos.Remove(a);
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
