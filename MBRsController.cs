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
    [Route("api/MBRs")]
    public class MBRsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MBRsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Application()
        {
            return View();
        }

        // GET: api/MBRs
        [HttpGet]
        public IEnumerable<MBR> GetMBRs()
        {
            return _context.MBRs;
        }

        // GET: api/MBRs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMBR([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mBR = await _context.MBRs.SingleOrDefaultAsync(m => m.Applicationid == id);

            if (mBR == null)
            {
                return NotFound();
            }

            return Ok(mBR);
        }

        // PUT: api/MBRs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMBR([FromRoute] int id, [FromBody] MBR mBR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mBR.Applicationid)
            {
                return BadRequest();
            }

            _context.Entry(mBR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MBRExists(id))
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

        // POST: api/MBRs
        [HttpPost]
        public async Task<IActionResult> PostMBR([FromBody] MBR mBR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MBRs.Add(mBR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMBR", new { id = mBR.Applicationid }, mBR);
        }

        // DELETE: api/MBRs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMBR([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mBR = await _context.MBRs.SingleOrDefaultAsync(m => m.Applicationid == id);
            if (mBR == null)
            {
                return NotFound();
            }

            _context.MBRs.Remove(mBR);
            await _context.SaveChangesAsync();

            return Ok(mBR);
        }

        private bool MBRExists(int id)
        {
            return _context.MBRs.Any(e => e.Applicationid == id);
        }
    }
}