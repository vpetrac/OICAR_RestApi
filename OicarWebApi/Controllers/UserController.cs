using Microsoft.AspNetCore.Mvc;
using OicarWebApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();
        // GET: api/<AppUserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            try
            {
                return await _context.AppUsers.FromSqlRaw($"readAppUsers").ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        // GET api/<AppUserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Get(int id)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(id);

                if (user == null) return NotFound();

                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<AppUserController>
        [HttpPost]
        public async Task<IActionResult> Post(AppUser user)
        {
            
            try
            {
                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return Created($"{user.IdappUser}", user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<AppUserController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id,AppUser user)
        {
            try
            {
                if (id != user.IdappUser)
                    return BadRequest("AppUser ID mismatch");

                /*var userToUpdate = await _context.AppUsers.FindAsync(id);

                if (userToUpdate == null)
                    return NotFound($"User with Id = {id} not found");*/

                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest("Server Error. User missing or wrong json.");
            }
        }

        // DELETE api/<AppUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userToDelete = await _context.AppUsers.FindAsync(id);
                if (userToDelete == null)
                {
                    return NotFound();
                }
                userToDelete.Deleted = true;
                _context.AppUsers.Update(userToDelete);
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
