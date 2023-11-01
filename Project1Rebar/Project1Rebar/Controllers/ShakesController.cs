using Microsoft.AspNetCore.Mvc;
using Project1Rebar.Models;
using Project1Rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShakesController : ControllerBase
    {
        private readonly IShakeService shakeService;
        public ShakesController(IShakeService shakeService)
        {
            this.shakeService = shakeService;
        }
        // GET: api/<ShakesController>
        [HttpGet]
        public List<Shake> Get()
        {
            return shakeService.Get();
        }

        // GET api/<ShakesController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
            var shake = shakeService.Get(id);
            if (shake == null)
            {
                return NotFound($"Shake with Id={id} not found");
            }
            return shake;
        }

        // POST api/<ShakesController>
        [HttpPost]
        public ActionResult Post([FromBody] Shake shake)
        {
            shakeService.Create(shake);
            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
        }

        // PUT api/<ShakesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Shake shake)
        {
            var existShake = shakeService.Get(id);
            if (existShake == null)
            {
                return NotFound($"Shake with Id={id} not found");
            }
            shakeService.Update(id, shake);
            return NoContent();
        }

        // DELETE api/<ShakesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var shake = shakeService.Get(id);
            if(shake==null)
            {
                return NotFound($"Shake with Id={id} not found");
            }
            shakeService.Remove(shake.Id);
            return Ok("Id:{id}");

        }
    }
}
