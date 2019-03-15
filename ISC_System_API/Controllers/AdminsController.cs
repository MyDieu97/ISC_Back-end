using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISC_System_API.Model;
using ISC_System_API.Model.Respone;
using ISC_System_API.Respone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISC_System_API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    public class AdminsController : Controller
    {
        private readonly Context _db;
        public AdminsController(Context db)
        {
            _db = db;
        }

        // GET: api/admins
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var listAdmin = await _db.Admins.ToListAsync();

            return new BaseRespone(listAdmin);
        }

        // GET: api/admins/id
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var admin = await _db.Admins.FindAsync(id);

            if (admin == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error get. This admin is not exists!"
                };
            }
            return new BaseRespone(admin);
        }

        // POST: api/admin
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(ADMIN admin)
        {
            var ad = await _db.Admins.Where(x => x.Adminid == admin.Adminid).FirstOrDefaultAsync();

            if (ad != null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error post. This admin is exists!"
                };
            }

            _db.Admins.Add(admin);
            await _db.SaveChangesAsync();

            CreatedAtAction("Get", new { id = admin.Adminid }, admin);
            return new BaseRespone
            {
                Message = "post is successful",
                Data = admin
            };
        }

        // PUT: api/admin/id
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, ADMIN admin)
        {
            var ad = await _db.Admins.FindAsync(id);

            if (ad == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error put. This admin is not exists!"
                };
            }

            ad.Adminid = admin.Adminid;
            ad.Username = admin.Username;
            ad.Password = admin.Password;
            ad.Fullname = admin.Fullname;
            //ad.image = company.PHONE;

            _db.Admins.Update(ad);
            await _db.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Put is successful",
                Data = ad
            };
        }

        // DELETE api/admin/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {
            var admin = await _db.Admins.FindAsync(id);
            if (admin == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Error delete. This admin is not exists!"
                };
            }
            _db.Admins.Remove(admin);
            await _db.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Delete is successful!",
                Data = admin
            };
        }
    }
}
