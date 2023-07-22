using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ProjectSEM3.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController:ControllerBase
    {
        private readonly ProjectSem3Context _context;
        public CartController(ProjectSem3Context context)
        {
            _context = context;
        }
        //[HttpGet,
        // Route("get")]
        //async public Task<IActionResult> GetAll()
        //{
        //    var itemsInCart = await _context.Carts.ToListAsync();
        //    List<CartDto> list = Mapper<Cart, CartDto>.MapList(itemsInCart);
        //    return Ok(list);
        //}

        [HttpGet]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var itemsInCart = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            List<CartDto> list = Mapper<Cart, CartDto>.MapList(itemsInCart);
            return Ok(list);
        }

        [HttpPost]
        async public Task<IActionResult> Create(CartDto data)
        {
            if (ModelState.IsValid)
            {
                var cart = Mapper<CartDto, Cart>.Map(data);
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
                return Ok("Created");
            }
            return BadRequest();
        }
        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
        [HttpPut]
        async public Task<IActionResult> Update(CartDto data)
            
        {
            var cart = await _context.Carts.FindAsync(data.Id);

            if (cart!=null)
            {
                try
                {
                    var updatedCart = Mapper<CartDto, Cart>.Map(data, cart);
                    _context.Carts.Update(updatedCart);
                    await _context.SaveChangesAsync();
                    return Ok("Updated");
                } catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("The product did not exist or something went wrong on our end, please try again!");
        }

    }
}
