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
        public async Task<ActionResult<Review>> Get(int id)
        {
            try
            {
                var review = await _context.Reviews.FindAsync(id);

                if (review == null) return NotFound();

                return review;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<ReviewController>
        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            try
            {
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();
                return Created($"{review.Idreview}", review);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id,Review review)
        {
            try
            {
                if (id != review.Idreview)
                    return BadRequest("Review ID mismatch");
                /*
                var reviewToUpdate = await _context.Reviews.FindAsync(id);

                if (reviewToUpdate == null)
                    return NotFound($"Review with Id = {id} not found");
                */
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }

        }
    }
}
