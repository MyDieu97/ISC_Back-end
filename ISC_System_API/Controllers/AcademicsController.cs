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
    public class AcademicsController : ControllerBase
    {
        private readonly Context _context;

        public AcademicsController(Context context)
        {
            _context = context;
        }

        // GET: api/Academics
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetAcademics()
        {
            return new BaseRespone
            {
                Message = "Get list success",
                Data = await _context.Academics.ToListAsync()
            };
        }

        // GET: api/Academics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetAcademic(int id)
        {
            var academic = await _context.Academics.FindAsync(id);

            if (academic == null)
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
                Data = academic
            };
        }

        // PUT: api/Academics/5
        [HttpPut("{id}")]
        public async Task<BaseRespone> PutAcademic(int id, Academic academic)
        {
            var updatedAcademic = await _context.Academics.FindAsync(id);
            if (updatedAcademic == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedAcademic.Id = academic.Id;
            updatedAcademic.Name = academic.Name;
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = academic
            };
        }

        // POST: api/BaseRespones
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostAcademic(Academic academic)
        {
            try
            {
                _context.Academics.Add(academic);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = academic
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

        // DELETE: api/BaseRespones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteAcademic(int id)
        {
            var academic = await _context.Academics.FindAsync(id);
            if (academic == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Academics.Remove(academic);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool AcademicExists(int id)
        {
            return _context.Academics.Any(e => e.Id == id);
        }
    }
}
