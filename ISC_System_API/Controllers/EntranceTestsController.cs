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
    [Route("api/EntranceTests")]
    [ApiController]
    public class EntranceTestsController : ControllerBase
    {
        private readonly Context _context;
        public EntranceTestsController(Context context)
        {
            _context = context;
        }
        // GET: api/EntranceTest
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var data = await _context.EntranceTests.ToListAsync();
            return new BaseRespone(data);
        }

        // GET: api/EntranceTest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var data = await _context.EntranceTests.FindAsync(id);
            return new BaseRespone(data);
        }

        // POST: api/EntranceTest
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(EntranceTest entrancetest)
        {
            try
            {
                _context.EntranceTests.Add(entrancetest);
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
        // PUT: api/EntranceTest/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(EntranceTest et, int id)
        {
            var newet = await _context.EntranceTests.FindAsync(id);
            if (newet == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }
            newet.Id = et.Id;
            newet.COURSEID = et.COURSEID;
            newet.TESTDATE = et.TESTDATE;
            _context.EntranceTests.Update(newet);
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
            var classDelete = await _context.EntranceTests.FindAsync(id);
            if (classDelete != null)
            {
                _context.EntranceTests.Remove(classDelete);
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
