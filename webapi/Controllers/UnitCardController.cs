using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitCardController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public UnitCardController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitCard>>> GetAll()
        {
            return await _context.UnitCards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitCard>> Get(Guid id)
        {
            var entity = await _context.UnitCards.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<UnitCard>> Create(UnitCard unitCard)
        {
            _context.UnitCards.Add(unitCard);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = unitCard.Id }, unitCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UnitCard unitCard)
        {
            if (id != unitCard.Id) return BadRequest();
            _context.Entry(unitCard).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UnitCards.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.UnitCards.FindAsync(id);
            if (entity == null) return NotFound();
            _context.UnitCards.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 