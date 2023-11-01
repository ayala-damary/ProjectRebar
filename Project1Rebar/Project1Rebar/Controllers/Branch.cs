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
    public class Branch : ControllerBase
    {
        private readonly IBranch _branch;
        public DatabaseOfBranchController(IBranch branch)
        {
            this._branch = branch;
        }

        // GET: api/<Branch>
        [HttpGet]
        public ActionResult<List<Account>> Get()
        {
            Console.WriteLine("enter passpord o mannager");
            string pws = Console.ReadLine();
            if (!pws.Equals("xxx"))
                return BadRequest("error passwrd!!!");
            return Branch.GetAccounts();
        }

        // GET api/<Branch>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Branch>
        [HttpPost]
        public ActionResult<Account> Post([FromBody] Account account)
        {
            //Only an manager can close a checkout, so we will check if it is an manager!!
            Console.WriteLine("enter passpord!!");
            string pws = Console.ReadLine();
            if (!pws.Equals("xxx"))
                return BadRequest("wrong password");
            Branch.CreateBranch(account);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }

        // PUT api/<Branch>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Branch>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
