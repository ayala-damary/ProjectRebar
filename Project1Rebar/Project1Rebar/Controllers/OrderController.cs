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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return _orderService.GetShakes();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
            var order = _orderService.GetShakeById(id);
            if (order == null) { NotFound($"order with Id={id} not found"); }
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<Shake> Post([FromBody] Shake shake)
        {
            if (shake == null)
            {
                return NotFound($"Shake with Id={shake.Id} not found");
            }
            if (string.IsNullOrEmpty(shake.Name))
            {
                return BadRequest("Name must not be empty.");
            }

            _orderService.CreateShakeInOrder(shake);
            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Shake shake)
        {
            var existingShake = _orderService.GetShakeById(id);
            if (existingShake == null)
            {
                return NotFound($"Shake with Id={id} not found");
            }
            if (shake == null)
            {
                return NotFound($"Shake with Id={shake.Id} not found");
            }
            if (string.IsNullOrEmpty(shake.Name))
            {
                return BadRequest("Name must not be empty.");
            }
            _orderService.UpdateOrderShake(id, shake);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var shake = _orderService.GetShakeById(id);
            if (shake == null) { NotFound($"Shake with Id={id} not found"); }
            _orderService.DeleteShake(shake.Id);
            return Ok($"Shake with Id ={id} deleted");
        }
    }
}
