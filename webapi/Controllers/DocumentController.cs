using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company.Entities;
using DBContext;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public DocumentController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> Get(Guid id)
        {
            var entity = await _context.Documents.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Document>> Create(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Document document)
        {
            if (id != document.Id) return BadRequest();
            _context.Entry(document).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Documents.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Documents.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Documents.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 