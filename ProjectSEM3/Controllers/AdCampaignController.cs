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
    [Route("api/adCampaign")]
    [ApiController]
    public class AdCampaignController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public AdCampaignController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var ads = await _context.AdCampaigns.ToListAsync();
                return Ok(ads);
            }
            var ad = await _context.AdCampaigns.FindAsync(id);

            if (ad == null) { return NotFound(); }
            return Ok(ad);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(AdCampaignDto data)
        {
            if (ModelState.IsValid)
            {
                _context.AdCampaigns.Add(new AdCampaign { Name = data.Name, Img = data.Img, Desciption = data.Desciption, OpenDate = data.OpenDate, EndDate = data.EndDate, PartnersId = data.PartnersId, CollectionId = data.CollectionId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(AdCampaign data)
        {
            if (ModelState.IsValid)
            {
                _context.AdCampaigns.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.AdCampaigns.Find(id);
            if (a != null)
            {
                _context.AdCampaigns.Remove(a);
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
