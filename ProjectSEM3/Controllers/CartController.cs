using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.DTOs.Auth;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ProjectSEM3.Services;

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

        [HttpGet]
        async  public Task<IActionResult> GetByUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.IsAuthenticated)
            {
                var UserId = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                var data = await _context.Carts.
                    Where(c => c.UserId == Convert.ToInt32(UserId)).
                    Select(e => new
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
                            e.ProductSize.Size,
                            ProductColor = new
                            {
                                e.ProductSize.ProductColor.Id,
                                e.ProductSize.ProductColor.Name,
                                e.ProductSize.ProductColor.ProductId,
                                e.ProductSize.ProductColor.Product,
                                e.ProductSize.ProductColor.ProductColorImages

                            }
                        }
                    }).ToListAsync();
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
                // check cart
                var checkCart = await _context.Carts.Where(e => e.ProductSizeId == productSizeId && e.UserId==UserId).FirstOrDefaultAsync();
                if (checkCart != null) return Ok(new {existed=true});
                // add new
                var c = new Cart { UserId = UserId, ProductSizeId = productSizeId, BuyQty = buyQty };
                await _context.Carts.AddAsync(c);
                await _context.SaveChangesAsync();
                var data = await _context.Carts.Where(e => e.Id == c.Id).
                    Select(e => new
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
                            e.ProductSize.Size,
                            ProductColor = new
                            {
                                e.ProductSize.ProductColor.Id,
                                e.ProductSize.ProductColor.Name,
                                e.ProductSize.ProductColor.ProductId,
                                e.ProductSize.ProductColor.Product,
                                e.ProductSize.ProductColor.ProductColorImages

                            }
                        }
                    }).FirstOrDefaultAsync();

                return Ok(data);
            }
            return Unauthorized(new { authErr = true });
        }

        [HttpDelete]
        async public Task<IActionResult> Delete(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
                return Ok(new {deleted=true});
            }
            return NotFound();
        }
        [HttpPut]
        async public Task<IActionResult> Update(CartDto data)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var cart = await _context.Carts.FindAsync(data.Id);
                if (cart != null)
                {
                    try
                    {
                        var updatedCart = Mapper<CartDto, Cart>.Map(data, cart);
                        _context.Carts.Update(updatedCart);
                        await _context.SaveChangesAsync();
                        return Ok(new {updated=true});
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return BadRequest("The product did not exist or something went wrong on our end, please try again!");
            }
            return Unauthorized();
        }

    }
}
