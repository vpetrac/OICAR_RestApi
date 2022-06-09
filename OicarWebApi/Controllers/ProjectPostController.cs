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
        public async Task<ProjectPost> Get(int id)
        {
            var projectPost = await _context.ProjectPosts.FindAsync(id);


            return projectPost;
        }


        // POST api/<ProjectPostController>
        [HttpPost]
        public async Task<IActionResult> Post(ProjectPost projectPost)
        {
            await _context.ProjectPosts.AddAsync(projectPost);
            await _context.SaveChangesAsync();
            return Created($"{projectPost.IdprojectPost}", projectPost);
        }

        // PUT api/<ProjectPostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ProjectPost projectPost)
        {
            _context.ProjectPosts.Update(projectPost);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ProjectPostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var projectPost = await _context.ProjectPosts.FindAsync(id);
            if (projectPost == null)
            {
                return NotFound();
            }
            _context.ProjectPosts.Remove(projectPost);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
