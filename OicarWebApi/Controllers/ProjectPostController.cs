using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectPostController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<ProjectPostController>
        [HttpGet]
        public async Task<List<ProjectPost>> Get()
        {
            var projectPosts = await _context.ProjectPosts.ToListAsync();
            return projectPosts;

        }

        // GET api/<ProjectPostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectPost>> Get(int id)
        {
            var projectPost = await _context.ProjectPosts.FindAsync(id);

            if(projectPost == null)
            {
                return NotFound();
            }

            return projectPost;
        }


        // POST api/<ProjectPostController>
        [HttpPost]
        public async Task<IActionResult> Post(ProjectPost projectPost)
        {
            try
            {
                await _context.ProjectPosts.AddAsync(projectPost);
                await _context.SaveChangesAsync();
                return Created($"{projectPost.IdprojectPost}", projectPost);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<ProjectPostController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id,ProjectPost projectPost)
        {
            try
            {
                if (id != projectPost.IdprojectPost)
                    return BadRequest("Project Post ID mismatch or missing. Check if JSON contains ProjectPost Primary Key");

                _context.ProjectPosts.Update(projectPost);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }

            


        }

        // DELETE api/<ProjectPostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var projectPost = await _context.ProjectPosts.FindAsync(id);
                if (projectPost == null)
                {
                    return NotFound();
                }
                projectPost.Deleted = true;
                _context.ProjectPosts.Update(projectPost);
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
