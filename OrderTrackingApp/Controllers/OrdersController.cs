using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderTrackingApp.Models;

namespace OrderTrackingApp.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OrdersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return _context.Order.Include(x => x.Status);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = _context.Order.Include(x => x.Status).First(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order.Status);
        }

        [HttpGet("statuses")]
        public IEnumerable<OrderStatus> GetOrderStatuses()
        {
            return _context.OrderStatus;
        }
    }
}