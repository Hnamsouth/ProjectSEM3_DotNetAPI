using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;

namespace ProjectSEM3.Controllers
{
    [Route("api/favorite")]
    [ApiController]
    public class FavoriteController : Controller
    {
        private readonly ProjectSem3Context _context;
        public FavoriteController(ProjectSem3Context context)
        {
            _context = context;
        }
        [HttpGet,
        Route ("get")]
        async public Task<IActionResult> GetAll()
        {
            var favouries =await _context.Favouries.ToListAsync();
            List<FavoriteDto> list = Mapper<Favoury,FavoriteDto>.MapList(favouries);
            return Ok(list);
        }
        [HttpGet]
        async public Task<IActionResult> GetByUser(int userId)
        {
            var itemInFavorite =await _context.Favouries.Where(f => f.UserId == userId).ToListAsync();
            List<FavoriteDto> list = Mapper<Favoury, FavoriteDto>.MapList(itemInFavorite);
            return Ok(list);
        }

        [HttpPost]
        async public Task<IActionResult> Create(FavoriteDto data)
        {
            if (ModelState.IsValid)
            {
                var favourite = Mapper<FavoriteDto, Favoury>.Map(data);
                await _context.Favouries.AddAsync(favourite);
                await _context.SaveChangesAsync();
                return Ok("Created");
            }
            return BadRequest();
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
