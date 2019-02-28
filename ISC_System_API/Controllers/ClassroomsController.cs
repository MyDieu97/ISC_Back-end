using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Model.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISC_System_API.Controllers
{
    [Route("api/classroom")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly Context _context;
        public ClassroomsController(Context context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRoom>>> Get()
        {
            return await _context.ClassRooms.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassRoom>> Get(int id)
        {
            return await _context.ClassRooms.FindAsync(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(ClassRoom classroom)
        {
            try
            {
                _context.ClassRooms.Add(classroom);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, ClassRoom clr)
        {
            var newclr = await _context.ClassRooms.FindAsync(id);
            if (newclr == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }
            newclr.Id = clr.Id;
            newclr.Name = clr.Name;
            newclr.ADDEDPERSON = clr.ADDEDPERSON;
            newclr.DATEADDED = clr.DATEADDED;
            newclr.CAPACITY = clr.CAPACITY;
            _context.ClassRooms.Update(newclr);
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {

            var classDelete = await _context.ClassRooms.FindAsync(id);
            if (classDelete != null)
            {
                _context.ClassRooms.Remove(classDelete);
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
    }
}
