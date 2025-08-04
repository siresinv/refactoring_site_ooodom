using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Company.Entities;
using DBContext;
using DBContext.Entities;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        public PhoneController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAll()
        {
            Console.WriteLine("123123");
            return await _context.Phones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> Get(Guid id)
        {
            var entity = await _context.Phones.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Phone>> Create(Phone phone)
        {
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = phone.Id }, phone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Phone phone)
        {
            if (id != phone.Id) return BadRequest();
            _context.Entry(phone).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Phones.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Phones.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Phones.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 