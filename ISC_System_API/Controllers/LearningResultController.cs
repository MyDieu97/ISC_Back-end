using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Request;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISC_System_API.Controllers
{
    [Route("api/LearResult")]
    [ApiController]
    public class LearningResultController : Controller
    {
        private readonly Context _context;

        public LearningResultController(Context context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get([FromQuery] LearningRequest req)
        {
            var learnignInfo = await _context.LearningResults.Include(p => p.CLASS).Include(p => p.STUDENT)
                        .Include(p => p.STUDENT.USER).AsNoTracking()
                        .Where(p => p.CLASSID == req.ClassId && p.CLASS.COURSEID == req.CourseId)
                        .Select(x => new LearningResultInfo
                        {
                            ClassId = x.CLASS.Id,
                            AVGSCORE = x.AVGSCORE,
                            ClassName = x.CLASS.Name,
                            Id = x.ID,
                            StudenId = x.IDSTUDENT,
                            FirstName = x.STUDENT.USER.FIRSTNAME,
                            LastName = x.STUDENT.USER.LASTNAME,
                            DoB = x.STUDENT.USER.DOB
                        }).ToListAsync();
            if(learnignInfo.Count == 0)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "NotFound"
                };
            }
            return new BaseRespone(learnignInfo);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var learn = await _context.LearningResults.FindAsync(id);
            return new BaseRespone(learn);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
