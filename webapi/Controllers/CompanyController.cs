using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext.Entities;
using DBContext;
using AutoMapper;
using DBContext.DTO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public CompanyController(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAll()
        {
            var companies = await _context.Companies
                .Include(c => c.CompanyCard)
                    .ThenInclude(cc => cc.Phones)
                .Include(c => c.CompanyCard)
                    .ThenInclude(cc => cc.Receptions)
                .Include(c => c.CompanyCard)
                    .ThenInclude(cc => cc.WorkHours)
                .ToListAsync();

            //var companies = await _context.Companies.ToListAsync();
            var companiesDTO = _mapper.Map<List<CompanyDTO>>(companies);
            //return await _context.Companies.ToListAsync();
            return Ok(companiesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(Guid id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> Create(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = company.Id }, companyDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Company company)
        {
            if (id != company.Id) return BadRequest();
            _context.Entry(company).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Companies.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 