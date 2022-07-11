using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        [HttpGet("UsersPosts/{userId}")]
        public async Task<List<ProjectPost>> GetForUser(int userId)
        {

            var projectPosts = await _context.ProjectPosts.Where(p => p.AppUserId == userId).ToListAsync();


            return projectPosts;
        }
    }
}
