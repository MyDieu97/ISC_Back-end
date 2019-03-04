using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IscSystemManagament.Models;
using IscSystemManagament.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IscSystemManagament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly Context _db;
        public CompaniesController(Context db)
        {
            _db = db;
        }

        // GET: api/company
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var companies = await _db.Companies.ToListAsync();

            return new BaseRespone(companies);
        }

        // GET: api/company/id
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var company = await _db.Companies.FindAsync(id);

            if (company == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error get. This company is not exists!"
                };
            }
            return new BaseRespone(company);
        }

        // POST: api/company
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(Company company)
        {
            var com = await _db.Companies.Where(x => x.Id == company.Id).FirstOrDefaultAsync();

            if (com != null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error post. This company is exists!"
                };
            }

            _db.Companies.Add(company);
            await _db.SaveChangesAsync();

            CreatedAtAction("Get", new { id = company.Id }, company);
            return new BaseResponse
            {
                Message = "Postted"
            };
        }

        // PUT: api/company/id
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, Company company)
        {
            var com = await _db.Companies.FindAsync(id);

            if (com == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error put. This company is not exists!"
                };
            }

            com.Id = company.Id;
            com.Name = company.Name;
            com.DIACHI = company.DIACHI;
            com.CONTECTPERSON = company.CONTECTPERSON;
            com.PHONE = company.PHONE;
            com.STATUS = company.STATUS;

            _db.Companies.Update(com);
            await _db.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Put is successfully"
            };
        }

        // DELETE api/Company/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {
            var company = await _db.Companies.FindAsync(id);
            if (company == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error delete. This company is not exists!"
                };
            }
            _db.Companies.Remove(company);
            await _db.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Deleted!",
                Data = company
            };
        }
    }
}
