using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public ReportController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetAll()
        {
            return await _context.Reports.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> Get(Guid id)
        {
            var entity = await _context.Reports.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Report>> Create(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Report report)
        {
            if (id != report.Id) return BadRequest();
            _context.Entry(report).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reports.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Reports.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Reports.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 