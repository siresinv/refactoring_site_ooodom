using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company.Entities;
using DBContext;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public ReceptionController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reception>>> GetAll()
        {
            return await _context.Receptions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reception>> Get(Guid id)
        {
            var entity = await _context.Receptions.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Reception>> Create(Reception reception)
        {
            _context.Receptions.Add(reception);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = reception.Id }, reception);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Reception reception)
        {
            if (id != reception.Id) return BadRequest();
            _context.Entry(reception).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Receptions.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Receptions.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Receptions.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 