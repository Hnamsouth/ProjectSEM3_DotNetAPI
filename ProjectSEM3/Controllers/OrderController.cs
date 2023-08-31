using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSEM3.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly ProjectSem3Context _context;
        private byte STS_PENDING = 0;
        private byte STS_PROCESSING = 1;
        private byte STS_DELEVERED = 2;
        private byte STS_COMPLETED = 3;
        private byte STS_DENIED = 4;
        private byte STS_REFUNDED = 5;
        private string DELIVERY_METHOD = "FREE SHIPPING";


        public OrderController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet,Route("get")]
        async public Task<IActionResult> Get(int? id)
        {

            if (id == null)
            {
                var orders = await _context.Orders.ToListAsync();
                return Ok(orders);
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }

        // POST api/<CategoryController>
        [HttpPost]
        async public Task<IActionResult> Create(OrderDto data)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.IsAuthenticated)
            {
                var UserId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (ModelState.IsValid)
                {
                    // add order
                    var order = new Order
                    {
                        Date = new DateTime().Date,
                        Status = STS_PENDING,
                        VoucherId = data.VoucherId,
                        UserId = Convert.ToInt32(UserId),
                        Firstname = data.Firstname,
                        Laststname = data.Laststname,
                        Street = data.Street,
                        City = data.City,
                        District = data.District,
                        Postcode = data.Postcode,
                        Phone = data.Phone,
                        Email = data.Email,
                        DeliveryMethod = DELIVERY_METHOD,
                        Country = data.Country,
                    };
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    // add order detail
                    var cart = await _context.Carts.Where(e => e.UserId == Convert.ToInt32(UserId)).ToListAsync();
                    cart.ForEach(async e =>
                    {
                        var orderdt = new OrderDetail { OrderId = order.Id, ProductSizeId = e.ProductSizeId, Qty = e.BuyQty };
                        await _context.OrderDetails.AddAsync(orderdt);
                    });
                    _context.Carts.RemoveRange(cart);
                    await _context.SaveChangesAsync();

                    var rs = await _context.Orders.Include(e => e.OrderDetails)
                        .Where(e => e.Id == order.Id).FirstOrDefaultAsync();

                    return Ok(rs);
                }
                return BadRequest();
            }
            return Unauthorized();
           
        }

        [HttpPost,Route("test"), AllowAnonymous]
        async public Task<IActionResult> CreateTest(OrderDto data)
        {
            if (ModelState.IsValid)
            {
                var UserId = 5;
                var order = new Order
                {
                    Date = new DateTime().Date,
                    Status = STS_PENDING,
                    VoucherId = data.VoucherId,
                    UserId = UserId,
                    Firstname = data.Firstname,
                    Laststname = data.Laststname,
                    Street = data.Street,
                    City = data.City,
                    District = data.District,
                    Postcode = data.Postcode,
                    Phone = data.Phone,
                    Email = data.Email,
                    DeliveryMethod = DELIVERY_METHOD,
                    Country = data.Country,
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                // add order detail
                var cart = await _context.Carts.Where(e => e.UserId == UserId).ToListAsync();
                 cart.ForEach(async e =>
                {
                    var orderdt = new OrderDetail { OrderId = order.Id, ProductSizeId = e.ProductSizeId, Qty = e.BuyQty };
                    await _context.OrderDetails.AddAsync(orderdt);
                });
                _context.Carts.RemoveRange(cart);
                await _context.SaveChangesAsync();

                var rs = await _context.Orders.Include(e => e.OrderDetails)
                    .Where(e => e.Id == order.Id).FirstOrDefaultAsync();

                return Ok(rs);
            }
            return BadRequest();
        }
    }
}

