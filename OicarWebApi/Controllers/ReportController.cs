using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<ReportReasonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> Get()
        {
            try
            {
                var report = await _context.Reports.ToListAsync();
                return report;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            

        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> Get(int id)
        {
            try
            {
                var report = await _context.Reports.FindAsync(id);
                if (report == null)
                {
                    return NotFound();
                }

                return report;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }

        // POST api/<ReportController>
        [HttpPost]
        public async Task<IActionResult> Post(Report report)
        {
            try
            {
                await _context.Reports.AddAsync(report);
                await _context.SaveChangesAsync();
                return Created($"{report.Idreport}", report);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Report report)
        {
            try
            {
                if (id != report.Idreport)
                    return BadRequest("Report ID mismatch");

                var reportToUpdate = await _context.Reports.FindAsync(id);

                if (reportToUpdate == null)
                    return NotFound($"Report with Id = {id} not found");

                _context.Reports.Update(report);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var report = await _context.Reports.FindAsync(id);
                if (report == null)
                {
                    return NotFound();
                }
                _context.Reports.Remove(report);
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

