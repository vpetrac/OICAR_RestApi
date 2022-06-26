﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // GET: api/<ReportReasonController>
        [HttpGet]
        public async Task<List<Report>> Get()
        {
            var report = await _context.Reports.ToListAsync();
            return report;

        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<Report> Get(int id)
        {
            var report = await _context.Reports.FindAsync(id);


            return report;
        }

        // POST api/<ReportController>
        [HttpPost]
        public async Task<IActionResult> Post(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return Created($"{report.Idreport}", report);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
    }
}

