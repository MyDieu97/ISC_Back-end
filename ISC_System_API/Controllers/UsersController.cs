﻿using System;
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
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetUsers()
        {
            return new BaseRespone
            {
                Data = await _context.Users.ToListAsync(),
            };       
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
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
                Data = user
            };
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> PutUser(int id, User user)
        {
            var updatedUser = await _context.Users.FindAsync(id);
            if (updatedUser == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }

            updatedUser.ADDRESS = user.ADDRESS;
            updatedUser.DOB = user.DOB;
            updatedUser.EMAIL = user.EMAIL;
            updatedUser.FIRSTNAME = user.FIRSTNAME;
            updatedUser.GENDER = user.GENDER;
            updatedUser.Id = user.Id;
            updatedUser.IDENTITYNUMBER = user.IDENTITYNUMBER;
            updatedUser.IsStudent = user.IsStudent;
            updatedUser.LASTNAME = user.LASTNAME;
            updatedUser.PHONE = user.PHONE;

            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();
            return new BaseRespone
            {
                Message = "Update success",
                Data = user
            };
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Added success",
                    Data = user
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Delete fail"
                };
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new BaseRespone
            {
                Message = "Delete success"
            };
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
