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
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public NewsController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var n = await _context.News.ToListAsync();
                return Ok(n);
            }
            var ns = await _context.News.FindAsync(id);

            if (ns == null) { return NotFound(); }
            return Ok(ns);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(NewsDto data)
        {
            if (ModelState.IsValid)
            {
                _context.News.Add(new News { Title = data.Title, ShortDescription = data.ShortDescription, Thumbnail = data.Thumbnail, Content = data.Content, CreatedAt = data.CreatedAt, UpdateAt = data.UpdateAt, AdminId = data.AdminId });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(News data)
        {
            if (ModelState.IsValid)
            {
                _context.News.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.News.Find(id);
            if (a != null)
            {
                _context.News.Remove(a);
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
