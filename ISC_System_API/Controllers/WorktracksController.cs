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
    public class WorktracksController : ControllerBase
    {
        private readonly Context _db;
        public WorktracksController(Context db)
        {
            _db = db;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetAll()
        {
            var list = await _db.Worktracks
                .Include(x => x.COMPANY.Id == x.COMPANYID)
                .Include(x => x.STUDENT.Id == x.IDSTUDENT)
                .Include(x => x.STUDENT.USER.Id == x.STUDENT.USERID)
                .Select(x => new WorktrackInfo
                {
                    Id = x.ID,
                    CompanyId = x.COMPANYID,
                    StudentId = x.IDSTUDENT,
                    CompanyName = x.COMPANY.Name,
                    StudentName = x.STUDENT.USER.LASTNAME + " " + x.STUDENT.USER.FIRSTNAME,
                    StartDate = x.STARTDATE,
                    ContractDate = x.CONTRACTDATE,
                    Note = x.NOTE
                })
                .ToListAsync();
            return new BaseRespone {
                ErrorCode = 0,
                Data = list
            };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var _worktrack = await _db.Worktracks.FindAsync(id);

            if (_worktrack == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error!! This worktrack is not exists!"
                };
            }

            return new BaseRespone(_worktrack);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(Worktrack worktrack)
        {
            var check = await _db.Worktracks.Where(s => s.ID == worktrack.ID).FirstOrDefaultAsync();

            if (check != null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error post. This worktrack is exists already!"
                };
            }
            _db.Worktracks.Add(worktrack);
            await _db.SaveChangesAsync();

            CreatedAtAction("Get", new { id = worktrack.ID }, worktrack);
            return new BaseRespone { Message = "Create successful!" };

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, Worktrack worktrack)
        {
            var check = await _db.Worktracks.FindAsync(id);

            if (check == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error!! This worktrack is not exist."
                };
            }

            check.ID = worktrack.ID;
            check.COMPANYID = worktrack.COMPANYID;
            check.IDSTUDENT = worktrack.IDSTUDENT;
            check.STARTDATE = worktrack.STARTDATE;
            check.CONTRACTDATE = worktrack.CONTRACTDATE;
            check.STATUS = worktrack.STATUS;
            check.NOTE = worktrack.NOTE;

            _db.Worktracks.Update(check);
            await _db.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Update successfully!"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {
            var _worktrack = await _db.Worktracks.FindAsync(id);
            if (_worktrack == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error delete. This worktrack is not exists!"
                };
            }
            _db.Worktracks.Remove(_worktrack);
            await _db.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Delete successfully",
                Data = _worktrack
            };
        }
    }
}
