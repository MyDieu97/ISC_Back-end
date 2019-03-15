using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Request;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISC_System_API.Controllers
{
    [Route("api/TestResults")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        private readonly Context _context;
        public TestResultsController(Context context)
        {
            _context = context;
        }
        // GET: api/TestResult
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var data =  await (from course in _context.Courses
                                    join entr in _context.EntranceTest on course.CourseId equals entr.COURSEID
                                    join sjentr in _context.SubjectEntranceTests on entr.Id equals sjentr.ENTRANCETESTID
                                    join exam in _context.ExaminationSubjects on sjentr.SUBJECTID equals exam.Id
                                    join test in _context.TestResults on sjentr.ID equals test.Subject_EntranceTestID
                                    join us in _context.Users on test.UserID equals us.Id
                                    select new TestResultRespone
                                    {
                                       TestResultId = test.Id,
                                       CourseName = course.Name,
                                       FirstName = us.FIRSTNAME,
                                       LastName = us.LASTNAME,
                                       Score = test.Score,
                                       SubjectName = exam.Name,
                                       TestDate = entr.TESTDATE
                                    }).ToListAsync();
            return new BaseRespone(data);
        }

        [HttpGet("GetByCoureAndEntrance")]
        public async Task<ActionResult<BaseRespone>> Getall([FromQuery] TestResultRequest req)
        {
            var data = await (
                              from course in _context.Courses
                              join entr in _context.EntranceTest on course.CourseId equals entr.COURSEID
                              join sjentr in _context.SubjectEntranceTests on entr.Id equals sjentr.ENTRANCETESTID
                              join exam in _context.ExaminationSubjects on sjentr.SUBJECTID equals exam.Id
                              join test in _context.TestResults on sjentr.ID equals test.Subject_EntranceTestID
                              join us in _context.Users on test.UserID equals us.Id
                              where course.CourseId == req.CousrseId && entr.Id == req.EntranceId
                              select new TestResultRespone
                              {
                                  TestResultId = test.Id,
                                  CourseName = course.Name,
                                  FirstName = us.FIRSTNAME,
                                  LastName = us.LASTNAME,
                                  Score = test.Score,
                                  SubjectName = exam.Name,
                                  TestDate = entr.TESTDATE
                              }).ToListAsync();
            return new BaseRespone(data);
        }

        [HttpGet("GetUserByCoureAndEntrance")]
        public async Task<ActionResult<BaseRespone>> GetUser([FromQuery] TestResultRequest req)
        {
            var data = await (
                              from course in _context.Courses
                              join entr in _context.EntranceTest on course.CourseId equals entr.COURSEID
                              join sjentr in _context.SubjectEntranceTests on entr.Id equals sjentr.ENTRANCETESTID
                              join exam in _context.ExaminationSubjects on sjentr.SUBJECTID equals exam.Id
                              join test in _context.TestResults on sjentr.ID equals test.Subject_EntranceTestID
                              join us in _context.Users on test.UserID equals us.Id
                              where course.CourseId == req.CousrseId && entr.Id == req.EntranceId
                              select new TestResultUserRespone
                              {
                                  id = us.Id,
                                  Firstname = us.FIRSTNAME,
                                  Lastname = us.LASTNAME
                              }).ToListAsync();
            return new BaseRespone(data);
        }

        [HttpGet("EntranceTest")]
        public async Task<ActionResult<BaseRespone>> GetEntrance(int id)
        {
            var data = await _context.EntranceTest.Where(p => p.COURSEID == id)
                .ToListAsync();
            return new BaseRespone(data);
        }

        // GET: api/TestResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var data = await _context.TestResults.FindAsync(id);
            return new BaseRespone(data);
        }

        // POST: api/TestResult
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(TestResult testresult)
        {
            try
            {
                _context.TestResults.Add(testresult);
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
        // PUT: api/TestResult/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, TestResultRespone tr)
        {
            var newtr = await _context.TestResults.FindAsync(id);
            if (newtr == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }
            newtr.Score = tr.Score;
            _context.TestResults.Update(newtr);
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update Success"
            };
        }

        // DELETE: api/TestResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {
            var classDelete = await _context.TestResults.FindAsync(id);
            if (classDelete != null)
            {
                _context.TestResults.Remove(classDelete);
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