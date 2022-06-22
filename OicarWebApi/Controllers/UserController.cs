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
        public async Task<List<AppUser>> Get()
        {
            var users = await _context.AppUsers.FromSqlRaw($"readAppUsers").ToListAsync();
            return users;

        }

        // GET api/<AppUserController>/5
        [HttpGet("{id}")]
        public async Task<AppUser> Get(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);


            return user;
        }

        // POST api/<AppUserController>
        [HttpPost]
        public async Task<IActionResult> Post(AppUser user)
        {
            
            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return Created($"{user.IdappUser}", user);
        }

        // PUT api/<AppUserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(AppUser user)
        {
            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<AppUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = await _context.AppUsers.FindAsync(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _context.AppUsers.Update(userToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
