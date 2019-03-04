using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISC_System_API;
using ISC_System_API.Model;
using ISC_System_API.Respone;

namespace ISC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly Context _context;

        public CoursesController(Context context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetAllCourses()
        {
            List<Course> list = await _context.Courses
                .AsNoTracking()
                .Select(x => new Course
                {
                    CourseId = x.CourseId,
                    Name = x.Name,
                    STARTDATE = x.STARTDATE,
                    ENDDATE = x.ENDDATE,
                    NOTE = x.NOTE
                })
                .ToListAsync();
            BaseRespone result = new BaseRespone();
            if (list != null)
            {
                result.ErrorCode = 0;
                result.Data = list;
            }
            else
            {
                result.ErrorCode = 1;
                result.Message = "Data is not available!";
            }
            return result;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return new BaseRespone {
                    ErrorCode = 1,
                    Message = "Object does not exist!"
                };
            }

            return new BaseRespone {
                ErrorCode = 0,
                Data = course
            };
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Object does not exist!"
                };
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                ErrorCode = 0,
                Message = "Object was deleted!"
            };
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
