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
    public class SpecializedTrainingsController : ControllerBase
    {
        private readonly Context _context;

        public SpecializedTrainingsController(Context context)
        {
            _context = context;
        }

        // GET: api/SpecializedTrainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecializedTraining>>> GetSpecializedTrainings()
        {
            return await _context.SpecializedTrainings.ToListAsync();
        }

        // GET: api/SpecializedTrainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecializedTraining>> GetSpecializedTraining(int id)
        {
            var specializedTraining = await _context.SpecializedTrainings.FindAsync(id);

            if (specializedTraining == null)
            {
                return NotFound();
            }

            return specializedTraining;
        }

        // PUT: api/SpecializedTrainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecializedTraining(int id, SpecializedTraining specializedTraining)
        {
            if (id != specializedTraining.Id)
            {
                return BadRequest();
            }

            _context.Entry(specializedTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializedTrainingExists(id))
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

        // POST: api/SpecializedTrainings
        [HttpPost]
        public async Task<ActionResult<SpecializedTraining>> PostSpecializedTraining(SpecializedTraining specializedTraining)
        {
            _context.SpecializedTrainings.Add(specializedTraining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecializedTraining", new { id = specializedTraining.Id }, specializedTraining);
        }

        // DELETE: api/SpecializedTrainings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecializedTraining>> DeleteSpecializedTraining(int id)
        {
            var specializedTraining = await _context.SpecializedTrainings.FindAsync(id);
            if (specializedTraining == null)
            {
                return NotFound();
            }

            _context.SpecializedTrainings.Remove(specializedTraining);
            await _context.SaveChangesAsync();

            return specializedTraining;
        }

        private bool SpecializedTrainingExists(int id)
        {
            return _context.SpecializedTrainings.Any(e => e.Id == id);
        }
    }
}
