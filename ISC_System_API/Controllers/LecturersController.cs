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
    public class LecturersController : ControllerBase
    {
        private readonly Context _context;

        public LecturersController(Context context)
        {
            _context = context;
        }

        // GET: api/Lecturers
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetLectures()
        {
            return new BaseRespone
            {
                Message = "Get list success",
                Data = await _context.Lectures.Include(item => item.USER)
                                                .Include(item => item.ACADEMIC)
                                                .Include(item => item.DEGREE).ToListAsync()
            };
        }

        // GET: api/Lecturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetLecturer(int id)
        {
            var lecturer = await _context.Lectures.FindAsync(id);

            if (lecturer == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            return new BaseRespone
            {
                Message = "Get success",
                Data = lecturer
            };
        }

        // PUT: api/Lecturers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> PutLecturer(int id, Lecturer lecturer)
        {
            var updatedLecturer = await _context.Lectures.FindAsync(id);
            if (updatedLecturer == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedLecturer.ACADEMICRANK = lecturer.ACADEMICRANK;
            updatedLecturer.DEGREEID = lecturer.DEGREEID;
            updatedLecturer.STARTDAY = lecturer.STARTDAY;
            updatedLecturer.USERID = lecturer.USERID;
            updatedLecturer.USE_USERID = lecturer.USE_USERID;
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = lecturer
            };
        }

        // POST: api/Lecturers
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostLecturer(Lecturer lecturer)
        {
            try
            {
                _context.Lectures.Add(lecturer);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = lecturer
                };
            }
            catch
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Adding fail"
                };
            }            
        }

        // DELETE: api/Lecturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteLecturer(int id)
        {
            var lecturer = await _context.Lectures.FindAsync(id);
            if (lecturer == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Lectures.Remove(lecturer);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool LecturerExists(int id)
        {
            return _context.Lectures.Any(e => e.USERID == id);
        }
    }
}
