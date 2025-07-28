using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company.Entities;
using DBContext;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public UnitController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAll()
        {
            return await _context.Units.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> Get(Guid id)
        {
            var entity = await _context.Units.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Unit unit)
        {
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = unit.Id }, unit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Unit unit)
        {
            if (id != unit.Id) return BadRequest();
            _context.Entry(unit).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Units.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Units.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Units.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 