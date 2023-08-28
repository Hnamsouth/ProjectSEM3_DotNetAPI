using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;

namespace ProjectSEM3.Controllers.Auth
{
    [Route("api/auth/admin")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class AdminsController : ControllerBase
    {
        private readonly ProjectSem3Context _context;

        public AdminsController(ProjectSem3Context context) {
            _context = context;
        }

        [HttpPost,Route("create")]
        [AllowAnonymous]
        async public Task<IActionResult> Create (AdminDtos data)
        {
            if (ModelState.IsValid)
            {
                var ad = new Admin { Role = data.Role, UserId = data.UserId };
                await _context.AddAsync(ad);
                _context.SaveChanges();
                return Ok(ad);
            }
            return BadRequest();
        }

        [HttpGet]
        async public Task<IActionResult> get()
        {
            var ad = await  _context.Admins.Include(e=>e.User).ToListAsync<Admin>();
            if(ad == null) return Unauthorized();
            return Ok(ad);
        }
    }
}
