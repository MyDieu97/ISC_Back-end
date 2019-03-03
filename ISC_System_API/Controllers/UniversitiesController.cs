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
    public class UniversitiesController : ControllerBase
    {
        private readonly Context _context;

        public UniversitiesController(Context context)
        {
            _context = context;
        }

        // GET: api/Universities
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetUniversitys()
        {
            return new BaseRespone
            {
                Message = "Get list success",
                Data = await _context.Universitys.ToListAsync()
            };
        }

        // GET: api/Universities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetUniversity(int id)
        {
            var university = await _context.Universitys.FindAsync(id);

            if (university == null)
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
                Data = university
            };
        }

        // PUT: api/Universities/5
        [HttpPut("{id}")]
        public async Task<BaseRespone> PutUniversity(int id, University university)
        {
            var updatedUniversity = await _context.Universitys.FindAsync(id);
            if (updatedUniversity == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedUniversity.Id = university.Id;
            updatedUniversity.Name = university.Name;
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = university
            };
        }

        // POST: api/Universities
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostUniversity(University university)
        {
            try
            {
                _context.Universitys.Add(university);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = university
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

        // DELETE: api/Universities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteUniversity(int id)
        {
            var university = await _context.Universitys.FindAsync(id);
            if (university == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Universitys.Remove(university);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool UniversityExists(int id)
        {
            return _context.Universitys.Any(e => e.Id == id);
        }
    }
}
