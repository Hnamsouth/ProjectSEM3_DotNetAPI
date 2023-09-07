using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSEM3.DTOs;
using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;
using ProjectSEM3.Services;

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
        private byte STS_CANCELLED = 5;
        private byte STS_UNPAID = 6;
        private string DELIVERY_METHOD = "FREE SHIPPING";


        public OrderController(ProjectSem3Context context)
        {
            _context = context;
        }

        [HttpGet,Route("get")]
        async public Task<IActionResult> Get(int? id)
        {
            if (id != null)
            {
                var order = await _context.Orders.Select(e => new
                {
                    e.Id,
                    e.Date,
                    e.Status,
                    e.UserId,
                    e.Firstname,
                    e.Laststname,
                    e.Street,
                    e.City,
                    e.District,
                    e.Postcode,
                    e.Phone,
                    e.Email,
                    e.DeliveryMethod,
                    e.Country,
                    e.VoucherId,
                    e.OrderIdPaypal,
                    e.Total,
                    OrderDetails = e.OrderDetails.Select(a => new
                    {
                        a.Id,
                        a.Qty,
                        a.Img,
                        a.OrderId,
                        a.Price,
                        a.ProductSizeId,
                        ProductSize = new
                        {
                            a.ProductSize.Id,a.ProductSize.Qty,a.ProductSize.Size
                        },
                    }),
                    e.User
                }).Where(e => e.Id == id).OrderByDescending(e => e.Id).FirstAsync();
                return Ok(order);
            }
            var orders = await _context.Orders.Select(e => new
            {
                e.Id,e.Date,e.Status,e.UserId,e.Firstname,e.Laststname,e.Street,e.City,e.District,e.Postcode,e.Phone,e.Email,e.DeliveryMethod,e.Country,e.VoucherId,e.OrderIdPaypal,e.Total,
                OrderDetails = e.OrderDetails.Select(a => new
                {
                    a.Id,a.Qty,a.Img,a.OrderId,a.Price,a.ProductSizeId,
                    ProductSize = new
                    {
                        a.ProductSize.Id,
                        a.ProductSize.Qty,
                        a.ProductSize.Size
                    }
                }),e.User
            }).OrderByDescending(e=>e.Id).ToListAsync();
            if (orders == null) { return NotFound(); }
            return Ok(orders);
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
                        Status = data.OrderIdPaypal!=null? STS_PENDING:STS_UNPAID,
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
                        Total = data.Total,
                        OrderIdPaypal = data.OrderIdPaypal,
                    };
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    // add order detail
                    var cart = await _context.Carts.Where(e => e.UserId == Convert.ToInt32(UserId)).Select(e => new
                    {
                        e.Id,
                        e.ProductSizeId,
                        e.BuyQty,
                        Img = e.ProductSize.ProductColor.ProductColorImages.FirstOrDefault().Url,
                        e.ProductSize.ProductColor.Product.Price,
                    }).ToListAsync();
                    var oId = order.Id;
                    cart.ForEach(async e =>
                    {
                        var orderdt = new OrderDetail
                        {
                            OrderId = oId,
                            ProductSizeId = e.ProductSizeId,
                            Qty = e.BuyQty,
                            Price = e.Price,
                            Img = e.Img
                        };
                        await _context.OrderDetails.AddAsync(orderdt);
                    });
                    await _context.Carts.Where(e => e.UserId == Convert.ToInt32(UserId)).ExecuteDeleteAsync();
                    await _context.SaveChangesAsync();

                    var rs = await _context.Orders.Select(e => new
                    {
                        e.Id,
                        e.Date,
                        e.Status,
                        e.UserId,
                        e.Firstname,
                        e.Laststname,
                        e.Street,
                        e.City,
                        e.District,
                        e.Postcode,
                        e.Phone,
                        e.Email,
                        e.DeliveryMethod,
                        e.Country,
                        e.VoucherId,
                        e.OrderIdPaypal,
                        e.Total,
                        OrderDetails = e.OrderDetails.Select(a => new
                        {
                            a.Id,
                            a.Qty,
                            a.Img,
                            a.OrderId,
                            a.Price,
                            a.ProductSizeId,
                            ProductSize = new
                            {
                                a.ProductSize.Id,
                                a.ProductSize.Qty,
                                a.ProductSize.Size
                            },
                        }),
                        e.User
                    }).Where(e => e.Id == order.Id).FirstOrDefaultAsync();

                    await PusherChannel.Trigger(new { mess="new" ,id= oId },"to-server","order");

                    return Ok(rs);
                }
                return BadRequest();
            }
            return Unauthorized();
           
        }

        [HttpPut,Route("payment")]
        async public Task<IActionResult> Payment(int id,string OrderIdPaypal)
        {
            var order= await _context.Orders.FindAsync(id);
            if(order==null) return NotFound();
            order.OrderIdPaypal = OrderIdPaypal;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return Ok(new {update=true });
        }

        [HttpPost, AllowAnonymous,Route("cancel")]
        async public Task<IActionResult> Cancel(int orderId)
        {
            try
            {
                var order = await _context.Orders.FindAsync(orderId);
                if (order.Status >= STS_DELEVERED) return Ok(new { status = false });
                // refund order in paypal
                var rs = await Paypal.RefundOrder(order.OrderIdPaypal);
                // set status order is STS_REFUNDED
                if (rs == null) return NotFound();

                order.Status = STS_CANCELLED;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                return Ok(new { status = true });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost,Route("cf-or-shipping"),AllowAnonymous]
        async public Task<IActionResult> Confirm (int c,int id)
        {
            var od = await _context.Orders.FindAsync(id);
            if (od == null) return NotFound();
            od.Status=c.Equals(0)?STS_PROCESSING:STS_DELEVERED;
            _context.Orders.Update(od);
            await _context.SaveChangesAsync();

            await PusherChannel.Trigger(new { mess = "order"}, "to-client", "user-update");
            return Ok(od);
        }

    }
}

