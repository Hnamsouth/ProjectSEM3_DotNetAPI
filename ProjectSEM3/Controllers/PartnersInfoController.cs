using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                var pnis = await _context.PartnersInfos.Include(e => e.Partners).ToListAsync();
                return Ok(pnis);
            }
            var pni = await _context.PartnersInfos.Include(e => e.Partners).Where(c => c.PartnersId == id).FirstOrDefaultAsync();

            if (pni == null) { return NotFound(); }
            return Ok(pni);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(PartnersInfoDto data)
        {
            if (ModelState.IsValid)
            {
                var pnInfo = new PartnersInfo { Phone = data.Phone, CompanyName = data.CompanyName, Address = data.Address, Img = data.Img, PartnersId = data.PartnersId };
                _context.PartnersInfos.Add(pnInfo);
        
               
                var pclImg = await UploadImg.UploadStr(data.Img, "Partner-info", (data.CompanyName ).Trim(), "#PP" + data.CompanyName.Trim());

                pnInfo.Img = pclImg.url;
                await _context.SaveChangesAsync();
                var pni = await _context.PartnersInfos.Include(e => e.Partners).Where(c => c.Id == pnInfo.Id).FirstOrDefaultAsync();

                return Created($"/get?id={data.Id}", pni);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        async public Task<IActionResult> Update(PartnersInfo data)
        {
            if (ModelState.IsValid)
            {
                _context.PartnersInfos.Update(data);
                await _context.SaveChangesAsync();
                return Ok(await _context.PartnersInfos.Include(e => e.Partners).Where(c => c.Id == data.Id).FirstOrDefaultAsync());
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

        [HttpGet, Route("upload-getImg")]
        async public Task<IActionResult> GetImgFolder()
        {
            var rs = await UploadImg.getImg(null);
            return Ok(rs);
        }
    }
}
