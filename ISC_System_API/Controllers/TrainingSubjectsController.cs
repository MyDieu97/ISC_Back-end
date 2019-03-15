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
    public class TrainingSubjectsController : ControllerBase
    {
        private readonly Context _context;

        public TrainingSubjectsController(Context context)
        {
            _context = context;
        }

        // GET: api/TrainingSubjects
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetTrainingSubjects()
        {
            List<TrainingSubject> list = await _context.TrainingSubject
                .AsNoTracking()
                .Select(x => new TrainingSubject
                {
                    TrainingSubjectId = x.TrainingSubjectId,
                    TrainingId = x.TrainingId,
                    SubjectId = x.SubjectId
                })
                .ToListAsync();
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

        // GET: api/TrainingSubjects/5
        [HttpGet("{trainingId}")]
        public async Task<ActionResult<List<TrainingSubject>>> GetTrainingSubjectByTrainingId(int trainingId)
        {
            List<TrainingSubject> trainingSubjects = await _context.TrainingSubject
                .Where(x => x.TrainingId == trainingId)
                .ToListAsync();

            if (trainingSubjects.Count() == 0)
            {
                return NotFound();
            }
            return trainingSubjects;
        }

        [Route("gettrainingsubject")]
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> GetTrainingSubject(TrainingSubject item)
        {
            TrainingSubject result = await _context.TrainingSubject
                .Where(x => x.TrainingId == item.TrainingId)
                .Where(x => x.SubjectId == item.SubjectId)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return new BaseRespone
                {
                    ErrorCode = 0,
                    Data = null
                };
            }
            return new BaseRespone {
                ErrorCode = 0,
                Data = result
            };
        }

        // PUT: api/TrainingSubjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingSubject(int id, TrainingSubject trainingSubject)
        {
            if (id != trainingSubject.TrainingSubjectId)
            {
                return BadRequest();
            }

            _context.Entry(trainingSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingSubjectExists(id))
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

        // POST: api/TrainingSubjects
        [HttpPost]
        public async Task<ActionResult<TrainingSubject>> PostTrainingSubject(TrainingSubject trainingSubject)
        {
            _context.TrainingSubject.Add(trainingSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingSubject", new { id = trainingSubject.TrainingSubjectId }, trainingSubject);
        }

        // DELETE: api/TrainingSubjects/5
        [HttpDelete("DeleteAllByTrainingId/{trainingId}")]
        public async Task<ActionResult<BaseRespone>> DeleteAllByTrainingId(int trainingId)
        {
            List<TrainingSubject> list = await _context.TrainingSubject
                .Where(x => x.TrainingId == trainingId)
                .ToListAsync();

            if (list.Count() == 0)
            {
                return NotFound();
            }
            else {
                foreach (TrainingSubject item in list)
                {
                    _context.TrainingSubject.Remove(item);
                }
            }

            await _context.SaveChangesAsync();

            return new BaseRespone {
                ErrorCode = 0,
                Message = "All subjects in training are deleted!"
            };
        }

        //[Route("DeleteTrainingSubject")]
        [HttpDelete("DeleteTrainingSubject/{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteTrainingSubject(int id)
        {
            var trainingSubject = await _context.TrainingSubject.FindAsync(id);
            if (trainingSubject == null)
            {
                return NotFound();
            }

            _context.TrainingSubject.Remove(trainingSubject);
            await _context.SaveChangesAsync();

            return new BaseRespone {
                ErrorCode = 0,
                Message = "Object Deleted!",
                Data = trainingSubject
            };
        }

        private bool TrainingSubjectExists(int id)
        {
            return _context.TrainingSubject.Any(e => e.TrainingSubjectId == id);
        }


    }
}
