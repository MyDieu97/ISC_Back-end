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
    public class CourseTrainingsController : ControllerBase
    {
        private readonly Context _context;

        public CourseTrainingsController(Context context)
        {
            _context = context;
        }

        // GET: api/CourseTrainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseTraining>>> GetCourseTraining()
        {
            return await _context.CourseTraining.ToListAsync();
        }

        // GET: api/CourseTrainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseTraining>> GetCourseTraining(int id)
        {
            var courseTraining = await _context.CourseTraining.FindAsync(id);

            if (courseTraining == null)
            {
                return NotFound();
            }

            return courseTraining;
        }

        // PUT: api/CourseTrainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseTraining(int id, CourseTraining courseTraining)
        {
            if (id != courseTraining.CourseTrainingId)
            {
                return BadRequest();
            }

            _context.Entry(courseTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseTrainingExists(id))
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

        // POST: api/CourseTrainings
        [HttpPost]
        public async Task<ActionResult<CourseTraining>> PostCourseTraining(CourseTraining courseTraining)
        {
            _context.CourseTraining.Add(courseTraining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseTraining", new { id = courseTraining.CourseTrainingId }, courseTraining);
        }

        // DELETE: api/CourseTrainings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseTraining>> DeleteCourseTraining(int id)
        {
            var courseTraining = await _context.CourseTraining.FindAsync(id);
            if (courseTraining == null)
            {
                return NotFound();
            }

            _context.CourseTraining.Remove(courseTraining);
            await _context.SaveChangesAsync();

            return courseTraining;
        }

        private bool CourseTrainingExists(int id)
        {
            return _context.CourseTraining.Any(e => e.CourseTrainingId == id);
        }
    }
}
