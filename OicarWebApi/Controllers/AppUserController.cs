﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppUserController : ControllerBase
    {
        // GET: api/<AppUserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AppUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppUserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
