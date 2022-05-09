using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuspensionController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<SuspensionController>
        [HttpGet]
        public async Task<List<Suspension>> Get()
        {
            var suspensions = await _context.Suspensions.ToListAsync();
            return suspensions;

        }

        // GET api/<SuspensionController>/5
        [HttpGet("{id}")]
        public async Task<Suspension> Get(int id)
        {
            var suspension = await _context.Suspensions.FindAsync(id);


            return suspension;
        }

        // POST api/<SuspensionController>
        [HttpPost]
        public async Task<IActionResult> Post(Suspension suspension)
        {
            await _context.Suspensions.AddAsync(suspension);
            await _context.SaveChangesAsync();
            return Created($"{suspension.Idsuspension}", suspension);
        }

        // PUT api/<SuspensionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Suspension suspension)
        {
            _context.Suspensions.Update(suspension);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<SuspensionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var suspension = await _context.Suspensions.FindAsync(id);
            if (suspension == null)
            {
                return NotFound();
            }
            _context.Suspensions.Remove(suspension);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
