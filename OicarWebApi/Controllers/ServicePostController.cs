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
        public async Task<ActionResult<IEnumerable<ServicePost>>> Get()
        {
            try
            {
                return await _context.ServicePosts.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/<ProjectPostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicePost>> Get(int id)
        {
            try
            {
                var servicePosts = await _context.ServicePosts.FindAsync(id);

                if (servicePosts == null) return NotFound();

                return servicePosts;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        // POST api/<ProjectPostController>
        [HttpPost]
        public async Task<IActionResult> Post(ServicePost servicePosts)
        { 
            try
            {
                await _context.ServicePosts.AddAsync(servicePosts);
                await _context.SaveChangesAsync();
                return Created($"{servicePosts.IdservicePost}", servicePosts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<ProjectPostController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id,ServicePost servicePosts)
        {
            try
            {
                if (id != servicePosts.IdservicePost)
                    return BadRequest("ServicePost ID mismatch");

                var servicePostToUpdate = await _context.ServicePosts.FindAsync(id);

                if (servicePostToUpdate == null)
                    return NotFound($"ServicePost with Id = {id} not found");

                _context.ServicePosts.Update(servicePosts);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest("Service Post ID mismatch or missing. Check if JSON contains ProjectPost Primary Key");
            }
        }

        // DELETE api/<ProjectPostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var servicePost = await _context.ServicePosts.FindAsync(id);
                if (servicePost == null)
                {
                    return NotFound();
                }
                servicePost.Deleted = true;
                _context.ServicePosts.Update(servicePost);
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
