using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicePostController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new Models.OicarAppDatabaseContext();

        // GET: api/<ProjeåctPostController>
        [HttpGet]
        public async Task<List<ServicePost>> Get()
        {
            var servicePosts = await _context.ServicePosts.ToListAsync();
            return servicePosts;

        }

        // GET api/<ProjectPostController>/5
        [HttpGet("{id}")]
        public async Task<ServicePost> Get(int id)
        {
            var servicePosts = await _context.ServicePosts.FindAsync(id);


            return servicePosts;
        }


        // POST api/<ProjectPostController>
        [HttpPost]
        public async Task<IActionResult> Post(ServicePost servicePosts)
        {
            await _context.ServicePosts.AddAsync(servicePosts);
            await _context.SaveChangesAsync();
            return Created($"{servicePosts.IdservicePost}", servicePosts);
        }

        // PUT api/<ProjectPostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ServicePost servicePosts)
        {
            _context.ServicePosts.Update(servicePosts);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ProjectPostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicePosts = await _context.ServicePosts.FindAsync(id);
            if (servicePosts == null)
            {
                return NotFound();
            }
            _context.ServicePosts.Remove(servicePosts);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
