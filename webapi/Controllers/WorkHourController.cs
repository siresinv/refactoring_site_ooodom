using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkHourController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public WorkHourController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkHour>>> GetAll()
        {
            return await _context.WorkHours.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkHour>> Get(Guid id)
        {
            var entity = await _context.WorkHours.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<WorkHour>> Create(WorkHour workHour)
        {
            _context.WorkHours.Add(workHour);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = workHour.Id }, workHour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, WorkHour workHour)
        {
            if (id != workHour.Id) return BadRequest();
            _context.Entry(workHour).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.WorkHours.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.WorkHours.FindAsync(id);
            if (entity == null) return NotFound();
            _context.WorkHours.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 