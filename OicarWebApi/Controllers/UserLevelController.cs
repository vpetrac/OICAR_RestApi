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
        public async Task<List<UserLevel>> Get()
        {
            var userLevels = await _context.UserLevels.ToListAsync();
            return userLevels;

        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<UserLevel> Get(int id)
        {
            var userLevel = await _context.UserLevels.FindAsync(id);


            return userLevel;
        }

        // POST api/<ReportController>
        [HttpPost]
        public async Task<IActionResult> Post(UserLevel userLevel)
        {
            await _context.UserLevels.AddAsync(userLevel);
            await _context.SaveChangesAsync();
            return Created($"{userLevel.IduserLevel}", userLevel);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UserLevel userLevel)
        {
            _context.UserLevels.Update(userLevel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
    }
}

