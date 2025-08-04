using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitDocumentController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public UnitDocumentController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDocument>>> GetAll()
        {
            return await _context.UnitDocuments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDocument>> Get(Guid id)
        {
            var entity = await _context.UnitDocuments.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<UnitDocument>> Create(UnitDocument unitDocument)
        {
            _context.UnitDocuments.Add(unitDocument);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = unitDocument.Id }, unitDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UnitDocument unitDocument)
        {
            if (id != unitDocument.Id) return BadRequest();
            _context.Entry(unitDocument).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UnitDocuments.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.UnitDocuments.FindAsync(id);
            if (entity == null) return NotFound();
            _context.UnitDocuments.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 