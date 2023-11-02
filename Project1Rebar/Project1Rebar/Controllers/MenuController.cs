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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return _menuService.GetShakes();
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
            var shake = _menuService.GetShakeById(id);
            if (shake == null) { NotFound($"Shake with Id={id} not found"); }
            return shake;
        }

        // POST api/<MenuController>
        [HttpPost]
        public ActionResult<Shake> Post([FromBody] Shake shake)
        {
            Valid validation = new Valid();
            if (!validation.shakeValid(shake).Equals("true"))
                return BadRequest(validation.shakeValid(shake));
            _menuService.Create(shake);
            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Shake shake)
        {

            var existingShake = _menuService.GetShakeById(id);
            if (existingShake == null)
            {
                return NotFound($"Shake with Id={id} not found");
            }
            Valid validation = new Valid();
            if (!validation.shakeValid(shake).Equals("true"))
                return BadRequest(validation.shakeValid(shake));
            _menuService.UpdateShake(id, shake);
            return NoContent();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var shake = _menuService.GetShakeById(id);
            if (shake == null) { NotFound($"Shake with Id:{id} not found"); }
            _menuService.RemoveShake(shake.Id);
            return Ok($"Shake with Id :{id} deleted");
        }
    }
}
