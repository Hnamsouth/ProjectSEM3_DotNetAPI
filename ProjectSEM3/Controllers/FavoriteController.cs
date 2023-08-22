using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;
using System.Security.Claims;

namespace ProjectSEM3.Controllers
{
    [Route("api/favorite")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly ProjectSem3Context _context;
        public FavoriteController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet]
        async public Task<IActionResult> GetByUser()
        {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var Id = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var itemInFavorite = await _context.Favouries.Where(f => f.UserId == Convert.ToInt32(Id)).Include(p => p.Product).ToListAsync();
                List<FavoriteDto> list = Mapper<Favoury, FavoriteDto>.MapList(itemInFavorite);
                return Ok(list);
            }
            return Unauthorized();

        }

        [HttpPost]

        async public Task<IActionResult> Create(int  productId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                 var UserId = Convert.ToInt32( identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                await _context.Favouries.AddAsync(new Favoury { UserId = UserId,ProductId = productId });
                await _context.SaveChangesAsync();
                return Ok("Created");
            }
            return Unauthorized();
        }
        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var favorite = await _context.Favouries.FindAsync(id);
            if (favorite != null)
            {
                _context.Favouries.Remove(favorite);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
       

    }
}
