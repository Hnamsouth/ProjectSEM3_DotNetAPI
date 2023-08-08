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
    [Route("api/kind-of-sport")]
    [ApiController]
    public class KindOfSportController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public KindOfSportController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var kops = await _context.KindOfSports.ToListAsync();
                return Ok(kops);
            }
            var kop = await _context.KindOfSports.FindAsync(id);

            if (kop == null) { return NotFound(); }
            return Ok(kop);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(KindOfSportDto data)
        {
            if (ModelState.IsValid)
            {
                _context.KindOfSports.Add(new KindOfSport { Name = data.Name});
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(KindOfSport data)
        {
            if (ModelState.IsValid)
            {
                _context.KindOfSports.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.KindOfSports.Find(id);
            if (a != null)
            {
                _context.KindOfSports.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
