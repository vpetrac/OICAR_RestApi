using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportReasonController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<ReportReasonController>
        [HttpGet]
        public async Task<List<ReportReason>> Get()
        {
            var reportReasons = await _context.ReportReasons.ToListAsync();
            return reportReasons;

        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<ReportReason> Get(int id)
        {
            var reportReason = await _context.ReportReasons.FindAsync(id);


            return reportReason;
        }

        // POST api/<ReportController>
        [HttpPost]
        public async Task<IActionResult> Post(ReportReason reportReason)
        {
            await _context.ReportReasons.AddAsync(reportReason);
            await _context.SaveChangesAsync();
            return Created($"{reportReason.IdreportReason}", reportReason);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ReportReason reportReason)
        {
            _context.ReportReasons.Update(reportReason);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reportReason = await _context.ReportReasons.FindAsync(id);
            if (reportReason == null)
            {
                return NotFound();
            }
            _context.ReportReasons.Remove(reportReason);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
