using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISC_System_API.Controllers
{
    [Route("api/ExaminationSubjects")]
    [ApiController]
    public class ExaminationSubjectsController : ControllerBase
    {
        private readonly Context _context;
        public ExaminationSubjectsController(Context context)
        {
            _context = context;
        }
        // GET: api/ExaminationSubject
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var data = await _context.ExaminationSubjects.ToListAsync();
            return new BaseRespone(data);
        }

        // GET: api/ExaminationSubject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var data = await _context.ExaminationSubjects.FindAsync(id);
            return new BaseRespone(data);
        }

        // POST: api/ExaminationSubject
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(ExaminationSubject examinationsubject)
        {
            try
            {
                _context.ExaminationSubjects.Add(examinationsubject);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Adding Success"
                };
            }
            catch
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Adding Fail"
                };
            }
        }
        // PUT: api/ExaminationSubject/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, ExaminationSubject es)
        {
            var newes = await _context.ExaminationSubjects.FindAsync(id);
            if (newes == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }
            newes.Id = es.Id;
            newes.Name = es.Name;
            _context.ExaminationSubjects.Update(newes);
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update Success"
            };
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {
            var classDelete = await _context.ExaminationSubjects.FindAsync(id);
            if (classDelete != null)
            {
                _context.ExaminationSubjects.Remove(classDelete);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Delete Success"
                };
            }
            return new BaseRespone
            {
                Message = "Delete Fail"
            };
        }
    }
}
