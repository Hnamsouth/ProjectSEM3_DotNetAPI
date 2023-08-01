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
    [Route("api/partner")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public PartnerController(ProjectSem3Context context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var pns = await _context.Partners.ToListAsync();
                return Ok(pns);
            }
            var pn = await _context.Partners.FindAsync(id);

            if (pn == null) { return NotFound(); }
            return Ok(pn);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(PartnerDto data)
        {
            if (ModelState.IsValid)
            {
                _context.Partners.Add(new Partner { RepresentativeName = data.RepresentativeName, Type = data.Type, Status = data.Status, Description = data.Description });
                await _context.SaveChangesAsync();
                return Created($"/get?id={data.Id}", data);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(Partner data)
        {
            if (ModelState.IsValid)
            {
                _context.Partners.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.Partners.Find(id);
            if (a != null)
            {
                _context.Partners.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
