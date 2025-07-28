using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company.Entities;
using DBContext;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public DocumentTypeController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentType>>> GetAll()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentType>> Get(Guid id)
        {
            var entity = await _context.DocumentTypes.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentType>> Create(DocumentType documentType)
        {
            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = documentType.Id }, documentType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DocumentType documentType)
        {
            if (id != documentType.Id) return BadRequest();
            _context.Entry(documentType).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DocumentTypes.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.DocumentTypes.FindAsync(id);
            if (entity == null) return NotFound();
            _context.DocumentTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 