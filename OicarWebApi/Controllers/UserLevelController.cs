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
    public class UserLevelController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<ReportReasonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLevel>>> Get()
        {
        
            try
            {
                return await _context.UserLevels.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLevel>> Get(int id)
        {
            try
            {
                var userLevel = await _context.UserLevels.FindAsync(id);

                if (userLevel == null) return NotFound();

                return userLevel;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<ReportController>
        [HttpPost]
        public async Task<IActionResult> Post(UserLevel userLevel)
        {
            
            try
            {
                await _context.UserLevels.AddAsync(userLevel);
                await _context.SaveChangesAsync();
                return Created($"{userLevel.IduserLevel}", userLevel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new record");
            }
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UserLevel userLevel)
        {

            try
            {
                if (id != userLevel.IduserLevel)
                    return BadRequest("UserLevel ID mismatch");

                var userLevelToUpdate = await _context.UserLevels.FindAsync(id);

                if (userLevelToUpdate == null)
                    return NotFound($"UserLevel with Id = {id} not found");

                _context.UserLevels.Update(userLevel);
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
                var userLevel = await _context.UserLevels.FindAsync(id);
                if (userLevel == null)
                {
                    return NotFound();
                }
                _context.UserLevels.Remove(userLevel);
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

