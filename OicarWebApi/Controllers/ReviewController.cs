using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<ReviewController>
        [HttpGet("GetForUser/{userId}")]
        public async Task<List<Review>> GetForUser(int userId)
        {
            var reviews = await _context.Reviews.Where(r => r.ReviewedUserId == userId).ToListAsync();
            return reviews;

        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public async Task<Review> Get(int id)
        {
            var review = await _context.Reviews.FindAsync(id);


            return review;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return Created($"{review.Idreview}", review);
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
