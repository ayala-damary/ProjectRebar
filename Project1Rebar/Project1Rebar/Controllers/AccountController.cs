using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1Rebar.Models;
using Project1Rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _accountService.GetOrders();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {

            var order = _accountService.GetOrderById(id);
            if (order == null)
            {
                NotFound($"Order with Id:{id} not found");
            }
            return order;
        }

        // POST api/<AccountController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            Valid validation = new Valid();
            if (!validation.orderValid(order))
                return BadRequest(validation.orderValid(order));
            _accountService.CreateOrder(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Order order)
        {
            Valid validation = new Valid();
            if (!validation.orderValid(order))
                return BadRequest(validation.orderValid(order));

            var existingOrder = _accountService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"order with Id:{id} not found");
            }
            _accountService.UpdateOrder(id, order);
            return NoContent();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var order = _accountService.GetOrderById(id);
            if (order == null)
            {
                NotFound($"order with Id={id} not found");
            }
            _accountService.DeleteOrder(order.Id);
            return Ok($"order with Id :{id} deleted");
        }
    }
}
