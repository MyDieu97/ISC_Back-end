﻿using System;
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
    [Route("api/classroom")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly Context _context;


        public ClassroomsController(Context context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> Get()
        {
            var classroom = await (from cl in _context.ClassRooms
                                   join us in _context.Users on cl.ADDEDPERSON equals us.Id
                                   select new ClassRoomInfo
                                   {
                                       ADDEDPERSON = cl.ADDEDPERSON,
                                       CAPACITY = cl.CAPACITY,
                                       DATEADDED = cl.DATEADDED,
                                       Id = cl.Id,
                                       Name = cl.Name,
                                       Person = us.FIRSTNAME + us.LASTNAME
                                   }).ToListAsync();

            return new BaseRespone(classroom);
        }


        [HttpGet("user")]
        public async Task<ActionResult<BaseRespone>> GetUsers(int id)
        {
            var FirstName = await _context.Users.Where(x => x.Id == id).Select(p => new { p.FIRSTNAME, p.LASTNAME }).ToListAsync();
            return new BaseRespone(FirstName);
            //string LastName = _context.Users.Where(x => x.Id == 1).Select(p => new {p.LASTNAME }).ToString();
            //return FirstName + LastName;
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> Get(int id)
        {
            var classroom = await _context.ClassRooms.FindAsync(id);
            return new BaseRespone(classroom);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> Post(ClassRoom classroom)
        {
            if (ExistClassroom(classroom)==false)
            {
                try
                {
                    _context.ClassRooms.Add(classroom);
                    await _context.SaveChangesAsync();
                    return new BaseRespone
                    {
                        ErrorCode = 0,
                        Message = "Added success"
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
            else
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Classroom has been ready!"
                };
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseRespone>> Put(int id, ClassRoom clr)
        {
            var newclr = await _context.ClassRooms.FindAsync(id);
            if (newclr == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Not Found"
                };
            }
            if (ExistClassroom(clr))
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Classroom has been ready!"
                };
            }
            else
            {
                newclr.Id = clr.Id;
                newclr.Name = clr.Name.Trim();
                newclr.ADDEDPERSON = clr.ADDEDPERSON;
                newclr.DATEADDED = clr.DATEADDED;
                newclr.CAPACITY = clr.CAPACITY;
                _context.ClassRooms.Update(newclr);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    ErrorCode = 0,
                    Message = "Update success"
                };
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> Delete(int id)
        {

            var classDelete = await _context.ClassRooms.FindAsync(id);
            if (classDelete != null)
            {
                _context.ClassRooms.Remove(classDelete);
                await _context.SaveChangesAsync();
                return new BaseRespone
                {
                    Message = "Delete success"
                };
            }
            return new BaseRespone
            {
                ErrorCode = 1,
                Message = "Delete fail"
            };
        }

        private Boolean ExistClassroom(ClassRoom clr)
        {
            var result = _context.ClassRooms.Where(x => x.Name.Equals(clr.Name.Trim())).ToList();
            if (result.Count == 0)
            {
                return false;
            }
            return true;
        }

    }
}
