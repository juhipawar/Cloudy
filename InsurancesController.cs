using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudAssign4.Data;
using CloudAssign4.Models;

namespace CloudAssign4.Controllers
{
    [Produces("application/json")]
    [Route("api/Insurances")]
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Insurances
        [HttpGet]
        public IEnumerable<Insurance> GetInsurances()
        {
            return _context.Insurances;
        }

        // GET: api/Insurances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsurance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = await _context.Insurances.SingleOrDefaultAsync(m => m.Insuranceid == id);

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        // PUT: api/Insurances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurance([FromRoute] int id, [FromBody] Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance.Insuranceid)
            {
                return BadRequest();
            }

            _context.Entry(insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Insurances
        [HttpPost]
        public async Task<IActionResult> PostInsurance([FromBody] Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsurance", new { id = insurance.Insuranceid }, insurance);
        }

        // DELETE: api/Insurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = await _context.Insurances.SingleOrDefaultAsync(m => m.Insuranceid == id);
            if (insurance == null)
            {
                return NotFound();
            }

            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync();

            return Ok(insurance);
        }

        private bool InsuranceExists(int id)
        {
            return _context.Insurances.Any(e => e.Insuranceid == id);
        }
    }
}