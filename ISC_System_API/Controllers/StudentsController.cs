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
    public class StudentsController : ControllerBase
    {
        private readonly Context _context;

        public StudentsController(Context context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetStudent()
        {
            return new BaseRespone
            {
                Message = "Get list success",
                Data = await _context.Students.Include(item => item.USER)
                                                .Include(item => item.UNIVERSITY)
                                                .Include(item => item.MAJOR).
                                                Select(item => new StudentInfo
                                                {
                                                    Id = item.Id,
                                                    CERTIFICATION = item.CERTIFICATION,
                                                    DEPOSITS = item.DEPOSITS,
                                                    USER = item.USER,
                                                    MAJOR = item.MAJOR,
                                                    UNIVERSITY = item.UNIVERSITY,
                                                    READYWORKDATE = item.READYWORKDATE
                                                }).ToListAsync()
            };
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
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
                Data = student
            };
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<BaseRespone> PutStudent(int id, Student student)
        {
            var updatedStudent = await _context.Students.FindAsync(id);
            if (updatedStudent == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedStudent.MAJORID = student.MAJORID;
            updatedStudent.UniverId = student.UniverId;
            updatedStudent.READYWORKDATE = student.READYWORKDATE;
            updatedStudent.USERID = student.USERID;
            updatedStudent.USERID = student.USERID;
            updatedStudent.CERTIFICATION = student.CERTIFICATION;
            updatedStudent.DEPOSITS = student.DEPOSITS;
            _context.Students.Update(updatedStudent);
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = student
            };
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = student
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

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
