using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;
using AutoMapper;
using DBContext.DTO;


namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyCardController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public CompanyCardController(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyCard>>> GetAll()
        {
            return await _context.CompanyCards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyCard>> Get(Guid id)
        {
            var entity = await _context.CompanyCards.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyCardDTO>> Create(CompanyCardDTO companyCardDTO)
        {
            var companyCard = _mapper.Map<CompanyCard>(companyCardDTO);
            _context.CompanyCards.Add(companyCard);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = companyCard.Id }, companyCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CompanyCard companyCard)
        {
            if (id != companyCard.Id) return BadRequest();
            _context.Entry(companyCard).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CompanyCards.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.CompanyCards.FindAsync(id);
            if (entity == null) return NotFound();
            _context.CompanyCards.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 