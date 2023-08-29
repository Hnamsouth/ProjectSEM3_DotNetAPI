using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace ProjectSEM3.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [Authorize(Policy ="Auth")]
    public class CartController:ControllerBase
    {
        private readonly ProjectSem3Context _context;
        public CartController(ProjectSem3Context context)
        {
            _context = context;
        }
        //[HttpGet, Route("get")]
        //async public Task<IActionResult> GetAll()
        //{
        //    var itemsInCart = await _context.Carts.ToListAsync();
        //    List<CartDto> list = Mapper<Cart, CartDto>.MapList(itemsInCart);
        //    return Ok(list);
        //}

        [HttpGet]
        async  public Task<IActionResult> GetByUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.IsAuthenticated)
            {
                var UserId = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                var data = await _context.Carts.Select(e => new
                {
                    e.Id,
                    e.BuyQty,
                    e.UserId,
                    e.ProductSizeId,
                    ProductSize = new
                    {
                        e.ProductSize.Id,
                        e.ProductSize.Qty,
                        e.ProductSize.SizeId,
                        e.ProductSize.ProductColorId,
                        ProductColor = new
                        {
                            e.ProductSize.ProductColor.Id,
                            e.ProductSize.ProductColor.Name,
                            e.ProductSize.ProductColor.ProductId,
                            e.ProductSize.ProductColor.Product,
                            e.ProductSize.ProductColor.ProductColorImages

                        }
                    }
                }).Where(c => c.UserId == Convert.ToInt32(UserId)).ToListAsync();
                return Ok(data);
            }
            return Unauthorized();
        }
 

        [HttpPost]
        async public Task<IActionResult> AddCart([FromQuery]int productSizeId, [FromQuery]int buyQty)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var UserId = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                var c = new Cart { UserId = UserId, ProductSizeId = productSizeId, BuyQty = buyQty };
                await _context.Carts.AddAsync(c);
                await _context.SaveChangesAsync();

                var data = await _context.Carts.Select(e => new
                {
                    e.Id,e.BuyQty,e.UserId,e.ProductSizeId,
                    ProductSize = new
                    {
                        e.ProductSize.Id,e.ProductSize.Qty,e.ProductSize.SizeId,e.ProductSize.ProductColorId,
                        ProductColor = new
                        {
                            e.ProductSize.ProductColor.Id,e.ProductSize.ProductColor.Name,e.ProductSize.ProductColor.ProductId,e.ProductSize.ProductColor.Product,
                            e.ProductSize.ProductColor.ProductColorImages
                        }
                    }
                }).Where(e => e.Id == c.Id).FirstOrDefaultAsync();

                return Ok(data);
            }
            return Unauthorized(new { authErr = true });
        }

        /*
        [HttpPost]
        [AllowAnonymous]
        async public Task<IActionResult> Create(int productSizeId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var UserId = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                await _context.Carts.AddAsync(new Cart { UserId = UserId, ProductSizeId = productSizeId });
                await _context.SaveChangesAsync();
                // var list = await _context.Favouries.ToListAsync();
                return Ok(productSizeId);
            }
            return Unauthorized(new { status = false });
        }
        */
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
