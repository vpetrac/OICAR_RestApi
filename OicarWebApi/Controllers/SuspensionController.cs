using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuspensionController : ControllerBase
    {
        // GET: api/<SuspensionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SuspensionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuspensionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuspensionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuspensionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
