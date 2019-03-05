using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly Context _db;
        public SubjectsController(Context db)
        {
            _db = db;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            return new BaseRespone(await _db.Subjects.ToListAsync());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var subject = await _db.Subjects.FindAsync(id);

            if (subject == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error get id. This subject is not exists!"
                };
            }

            return new BaseRespone(subject);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(Subject subject)
        {
            var _subject = await _db.Subjects.Where(s => s.SubjectId == subject.SubjectId).FirstOrDefaultAsync();

            if (_subject != null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error post. This subject is exists already!"
                };
            }
            _db.Subjects.Add(subject);
            await _db.SaveChangesAsync();

            CreatedAtAction("Get", new { id = subject.SubjectId }, subject);
            return new BaseRespone
            {
                Message = "Post is successful!",
                Data = subject
            };

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, Subject subject)
        {
            var _subject = await _db.Subjects.FindAsync(id);

            if (_subject == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error put. This subject is not exists!"
                };
            }

            _subject.SubjectId = subject.SubjectId;
            _subject.Name = subject.Name;
            _subject.NUMBERLESSON = subject.NUMBERLESSON;

            _db.Subjects.Update(_subject);
            await _db.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Put is successful!",
                Data = _subject
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {
            var _subject = await _db.Subjects.FindAsync(id);
            if (_subject == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error delete. This company is not exists!"
                };
            }
            _db.Subjects.Remove(_subject);
            await _db.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Delete is successfully",
                Data = _subject
            };
        }
    }
}
