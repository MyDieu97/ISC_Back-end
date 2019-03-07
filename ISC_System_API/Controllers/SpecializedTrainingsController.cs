using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISC_System_API;
using ISC_System_API.Model;
using Microsoft.AspNetCore.Authorization;
using ISC_System_API.Respone;
using ISC_System_API.Model.Respone;

namespace ISC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializedTrainingsController : ControllerBase
    {
        private readonly Context _context;

        public SpecializedTrainingsController(Context context)
        {
            _context = context;
        }

        // GET: api/SpecializedTrainings
        //[HttpGet]
        //public async Task<ActionResult<BaseRespone>> GetAllSpecializedTrainings()
        //{
        //    List<SpecializedTraining> list = await _context.SpecializedTrainings
        //        .AsNoTracking()
        //        .Select(x => new SpecializedTraining
        //        {
        //            TrainingId = x.TrainingId,
        //            Name = x.Name,
        //            NUMBERWEEK = x.NUMBERWEEK
        //        })
        //        .ToListAsync();
        //    BaseRespone result = new BaseRespone();
        //    if (list != null)
        //    {
        //        result.ErrorCode = 0;
        //        result.Data = list;
        //    }
        //    else {
        //        result.ErrorCode = 1;
        //        result.Message = "Data is not available!";
        //    }
        //    return result;
        //}

        //[Route("GetAllWithSubject")]
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetWithSubject()
        {
            List<SpecTrainingInfo> list = await _context.SpecializedTrainings
                .AsNoTracking()
                .Select(x => new SpecTrainingInfo
                {
                    TrainingId = x.TrainingId,
                    Name = x.Name,
                    NumberofWeeks = x.NumberofWeeks
                })
                .ToListAsync();
            foreach (SpecTrainingInfo item in list)
            {
                item.listSubjects = await _context.TrainingSubject
                    .AsNoTracking()
                    .Where(x => x.TrainingId == item.TrainingId)
                    .Select(x => new Subject
                    {
                        SubjectId = x.SubjectId,
                        Subjectname = x.SUBJECTS.Subjectname,
                        NUMBERLESSON = x.SUBJECTS.NUMBERLESSON
                    })
                    .ToListAsync();
            }
              
            BaseRespone result = new BaseRespone();
            if (list != null)
            {
                result.ErrorCode = 0;
                result.Data = list;
            }
            else
            {
                result.ErrorCode = 1;
                result.Message = "Data is not available!";
            }
            return result;
        }

        // GET: api/SpecializedTrainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetSpecializedTraining(int id)
        {
            BaseRespone result = new BaseRespone();
            var item = await _context.SpecializedTrainings
                .AsNoTracking()
                .Select(x => new SpecTrainingInfo
                {
                    TrainingId = x.TrainingId,
                    Name = x.Name,
                    NumberofWeeks = x.NumberofWeeks
                })
                .FirstOrDefaultAsync(x => x.TrainingId == id);

            item.listSubjects = await _context.TrainingSubject
                    .AsNoTracking()
                    .Where(x => x.TrainingId == item.TrainingId)
                     .Select(x => new Subject
                     {
                         SubjectId = x.SubjectId,
                         Subjectname = x.SUBJECTS.Subjectname,
                         NUMBERLESSON = x.SUBJECTS.NUMBERLESSON
                     })
                    .ToListAsync();

            if (item == null)
            {
                result.ErrorCode = 404;
                result.Message = "Not found";
            }
            else {
                result.ErrorCode = 0;
                result.Data = item;
            }
            return result;
        }

        [Route("getthelast")]
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetTheLast()
        {
            var item =  _context.SpecializedTrainings.Last();

            return new BaseRespone {
                ErrorCode = 0,
                Data = item
            };
        }

        // PUT: api/SpecializedTrainings/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutSpecializedTraining(int id, SpecializedTraining specializedTraining)
        {
            if (id != specializedTraining.TrainingId)
            {
                return BadRequest();
            }

            _context.Entry(specializedTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializedTrainingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SpecializedTrainings
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BaseRespone>> PostSpecializedTraining(SpecializedTraining specializedTraining)
        {
            try
            {
                _context.SpecializedTrainings.Add(specializedTraining);
                await _context.SaveChangesAsync();

                return new BaseRespone
                {
                    Message = "Add successfully!"
                };
            }
            catch
            {
                return new BaseRespone
                {
                    Message = "Add fail!"
                };
            }
            //_context.SpecializedTrainings.Add(specializedTraining);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSpecializedTraining", new { id = specializedTraining.TrainingId }, specializedTraining);
        }


        // DELETE: api/SpecializedTrainings/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseRespone>> DeleteSpecializedTraining(int id)
        {
            var specializedTraining = await _context.SpecializedTrainings.FindAsync(id);
            if (specializedTraining == null)
            {
                return new BaseRespone {
                    ErrorCode = 1,
                    Message = "Object does not exist!"
                };
            }

            _context.SpecializedTrainings.Remove(specializedTraining);
            await _context.SaveChangesAsync();

            return new BaseRespone {
                ErrorCode = 0,
                Message = "Object was deleted!"
            };
        }

        private bool SpecializedTrainingExists(int id)
        {
            return _context.SpecializedTrainings.Any(e => e.TrainingId == id);
        }
    }
}
