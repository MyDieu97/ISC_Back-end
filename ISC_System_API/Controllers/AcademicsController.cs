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
    public class AcademicsController : ControllerBase
    {
        private readonly Context _context;

        public AcademicsController(Context context)
        {
            _context = context;
        }

        // GET: api/Academics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Academic>>> GetAcademics()
        {
            return await _context.Academics.ToListAsync();
        }

        // GET: api/Academics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Academic>> GetAcademic(int id)
        {
            var academic = await _context.Academics.FindAsync(id);

            if (academic == null)
            {
                return NotFound();
            }

            return academic;
        }

        // PUT: api/Academics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademic(int id, Academic academic)
        {
            if (id != academic.Id)
            {
                return BadRequest();
            }

            _context.Entry(academic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicExists(id))
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

        // POST: api/Academics
        [HttpPost]
        public async Task<ActionResult<Academic>> PostAcademic(Academic academic)
        {
            _context.Academics.Add(academic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademic", new { id = academic.Id }, academic);
        }

        // DELETE: api/Academics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Academic>> DeleteAcademic(int id)
        {
            var academic = await _context.Academics.FindAsync(id);
            if (academic == null)
            {
                return NotFound();
            }

            _context.Academics.Remove(academic);
            await _context.SaveChangesAsync();

            return academic;
        }

        private bool AcademicExists(int id)
        {
            return _context.Academics.Any(e => e.Id == id);
        }
    }
}
