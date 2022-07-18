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
        public async Task<ActionResult<IEnumerable<Suspension>>> Get()
        {
            try
            {
                return await _context.Suspensions.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        // GET api/<SuspensionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suspension>> Get(int id)
        {
            try
            {
                var suspension = await _context.Suspensions.FindAsync(id);

                if (suspension == null) return NotFound();

                return suspension;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<SuspensionController>
        [HttpPost]
        public async Task<IActionResult> Post(Suspension suspension)
        {
            try
            {
                await _context.Suspensions.AddAsync(suspension);
                await _context.SaveChangesAsync();
                return Created($"{suspension.Idsuspension}", suspension);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<SuspensionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Suspension suspension)
        {
            try
            {
                if (id != suspension.Idsuspension)
                    return BadRequest("Suspension ID mismatch");
                /*
                var suspensionToUpdate = await _context.Suspensions.FindAsync(id);

                if (suspensionToUpdate == null)
                    return NotFound($"Suspension with Id = {id} not found");
                */
                _context.Suspensions.Update(suspension);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<SuspensionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }
        }
    }
}
