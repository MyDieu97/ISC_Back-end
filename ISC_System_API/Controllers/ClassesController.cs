using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Request;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : Controller
    {
        private readonly Context _context;


        public ClassesController(Context context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var classes = await _context.Class.Include(p => p.COURSE).Include(p => p.SUBJECT)
                          .Where(p=> p.ISDELETE == false).ToListAsync();
            return new BaseRespone(classes);
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var classes = await _context.Class.FindAsync(id);
            return new BaseRespone(classes);
        }

        [HttpGet("GetCourse")]
        public async Task<ActionResult<BaseRespone>> GetOne( int id)
        {
            var classes = await _context.Class.Where(p => p.COURSEID == id).ToListAsync();
            return new BaseRespone(classes);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(Class classes)
        {
            if(ExistCourseAndSubject(classes) == false)
            {
                try
                {
                    _context.Class.Add(classes);
                    await _context.SaveChangesAsync();
                    return new BaseRespone
                    {
                        ErrorCode = 0,
                        Message = "Added success"
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
            else
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Course and Subject has been ready!"
                };
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, Class cls)
        {
            var newclass = await _context.Class.FindAsync(id);
            if (newclass == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }
            if (ExistCourseAndSubject(cls))
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Course and Subject has been ready!"
                };
            }
            else
            {
                newclass.Id = cls.Id;
                newclass.COURSEID = cls.COURSEID;
                newclass.SUBJECTID = cls.SUBJECTID;
                newclass.PASSINGSCORE = cls.PASSINGSCORE;
                newclass.PercentBan = cls.PercentBan;
                newclass.Name = cls.Name;
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    ErrorCode = 0,
                    Message = "Update success"
                };
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {

            var classDelete = await _context.Class.FindAsync(id);
            if (classDelete != null)
            {
                classDelete.ISDELETE = true;
                _context.Class.Update(classDelete);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Delete success"
                };
            }
            return new BaseRespone
            {
                ErrorCode = 1,
                Message = "Delete fail"
            };
        }

        private Boolean ExistCourseAndSubject(Class cls)
        {
            var result = _context.Class.Where(x=>x.SUBJECTID == cls.SUBJECTID && x.COURSEID == cls.COURSEID).ToList();
            if (result.Count == 0)
            {
                return false;
            } return true;
        }
    }
}
