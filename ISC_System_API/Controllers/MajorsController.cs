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
    public class MajorsController : ControllerBase
    {
        private readonly Context _context;

        public MajorsController(Context context)
        {
            _context = context;
        }

        // GET: api/Majors
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetMajors()
        {
            return new BaseRespone
            {
                Message = "Get list success",
                Data = await _context.Majors.ToListAsync()
            };
        }

        // GET: api/Majors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetMajor(int id)
        {
            var major = await _context.Majors.FindAsync(id);

            if (major == null)
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
                Data = major
            };
        }

        // PUT: api/Majors/5
        [HttpPut("{id}")]
        public async Task<BaseRespone> PutMajor(int id, Major major)
        {
            var updatedAcademic = await _context.Majors.FindAsync(id);
            if (updatedAcademic == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedAcademic.Id = major.Id;
            updatedAcademic.Name = major.Name;
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = major
            };
        }

        // POST: api/Majors
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostMajor(Major major)
        {
            try
            {
                _context.Majors.Add(major);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = major
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

        // DELETE: api/Majors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteMajor(int id)
        {
            var major = await _context.Majors.FindAsync(id);
            if (major == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Majors.Remove(major);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool MajorExists(int id)
        {
            return _context.Majors.Any(e => e.Id == id);
        }
    }
}
