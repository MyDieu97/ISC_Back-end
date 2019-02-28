using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISC_System_API;
using ISC_System_API.Model;

namespace ISC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly Context _context;

        public DegreesController(Context context)
        {
            _context = context;
        }

        // GET: api/Degrees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Degree>>> GetDegrees()
        {
            return await _context.Degrees.ToListAsync();
        }

        // GET: api/Degrees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Degree>> GetDegree(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);

            if (degree == null)
            {
                return NotFound();
            }

            return degree;
        }

        // PUT: api/Degrees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDegree(int id, Degree degree)
        {
            if (id != degree.Id)
            {
                return BadRequest();
            }

            _context.Entry(degree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(id))
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

        // POST: api/Degrees
        [HttpPost]
        public async Task<ActionResult<Degree>> PostDegree(Degree degree)
        {
            _context.Degrees.Add(degree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDegree", new { id = degree.Id }, degree);
        }

        // DELETE: api/Degrees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Degree>> DeleteDegree(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }

            _context.Degrees.Remove(degree);
            await _context.SaveChangesAsync();

            return degree;
        }

        private bool DegreeExists(int id)
        {
            return _context.Degrees.Any(e => e.Id == id);
        }
    }
}
