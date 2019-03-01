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
    public class DegreesController : ControllerBase
    {
        private readonly Context _context;

        public DegreesController(Context context)
        {
            _context = context;
        }

        // GET: api/Degrees
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetDegrees()
        {
            return new BaseRespone
            {
                Message = "Get list success",
                Data = await _context.Degrees.ToListAsync()
            };
        }

        // GET: api/Degrees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetDegree(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);

            if (degree == null)
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
                Data = degree
            };
        }

        // PUT: api/Degrees/5
        [HttpPut("{id}")]
        public async Task<BaseRespone> PutDegree(int id, Degree degree)
        {
            var updatedDegree = await _context.Degrees.FindAsync(id);
            if (updatedDegree == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedDegree.Id = degree.Id;
            updatedDegree.Name = degree.Name;
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = degree
            };
        }

        // POST: api/Degrees
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostDegree(Degree degree)
        {
            try
            {
                _context.Degrees.Add(degree);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = degree
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

        // DELETE: api/Degrees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteDegree(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Degrees.Remove(degree);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool DegreeExists(int id)
        {
            return _context.Degrees.Any(e => e.Id == id);
        }
    }
}
