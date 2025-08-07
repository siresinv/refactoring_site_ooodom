using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;
using DBContext.DTO;
using System;
using System.Threading.Tasks;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyUpdateController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public CompanyUpdateController(CompanyDbContext context)
        {
            _context = context;
        }

        // DTO для обновления компании с карточкой
        public class UpdateCompanyWithCardRequest
        {
            public Guid CompanyId { get; set; }
            public string Name { get; set; } = null!;
            public string Shortname { get; set; } = null!;
            public CompanyCardUpdateData CompanyCard { get; set; } = null!;
        }

        public class CompanyCardUpdateData
        {
            public string DirectorFullName { get; set; } = null!;
            public string SertificateGRUL { get; set; } = null!;
            public string Post { get; set; } = null!;
            public string Address { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Site { get; set; } = null!;
            public string? LocationLink { get; set; }
        }

        // POST метод для обновления компании и связанной карточки
        [HttpPost("update-company-with-card")]
        public async Task<IActionResult> UpdateCompanyWithCard([FromBody] UpdateCompanyWithCardRequest request)
        {
            try
            {
                // Находим компанию с включенной карточкой
                var company = await _context.Companies
                    .Include(c => c.CompanyCard)
                    .FirstOrDefaultAsync(c => c.Id == request.CompanyId);

                if (company == null)
                {
                    return NotFound($"Компания с ID {request.CompanyId} не найдена");
                }

                // Обновляем данные компании
                company.Name = request.Name;
                company.Shortname = request.Shortname;

                // Обновляем или создаем карточку компании
                if (company.CompanyCard == null)
                {
                    // Создаем новую карточку, если её нет
                    company.CompanyCard = new CompanyCard
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = company.Id,
                        DirectorFullName = request.CompanyCard.DirectorFullName,
                        SertificateGRUL = request.CompanyCard.SertificateGRUL,
                        Post = request.CompanyCard.Post,
                        Address = request.CompanyCard.Address,
                        Email = request.CompanyCard.Email,
                        Site = request.CompanyCard.Site,
                        LocationLink = request.CompanyCard.LocationLink
                    };
                }
                else
                {
                    // Обновляем существующую карточку
                    company.CompanyCard.DirectorFullName = request.CompanyCard.DirectorFullName;
                    company.CompanyCard.SertificateGRUL = request.CompanyCard.SertificateGRUL;
                    company.CompanyCard.Post = request.CompanyCard.Post;
                    company.CompanyCard.Address = request.CompanyCard.Address;
                    company.CompanyCard.Email = request.CompanyCard.Email;
                    company.CompanyCard.Site = request.CompanyCard.Site;
                    company.CompanyCard.LocationLink = request.CompanyCard.LocationLink;
                }

                // Сохраняем изменения в базе данных
                await _context.SaveChangesAsync();

                // Возвращаем обновленные данные
                var result = new
                {
                    Company = new CompanyDTO
                    {
                        Id = company.Id,
                        Name = company.Name,
                        Shortname = company.Shortname
                    },
                    CompanyCard = new CompanyCardDTO
                    {
                        Id = company.CompanyCard.Id,
                        DirectorFullName = company.CompanyCard.DirectorFullName,
                        SertificateGRUL = company.CompanyCard.SertificateGRUL,
                        Post = company.CompanyCard.Post,
                        Address = company.CompanyCard.Address,
                        Email = company.CompanyCard.Email,
                        Site = company.CompanyCard.Site,
                        LocationLink = company.CompanyCard.LocationLink
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        // Альтернативный метод для обновления только карточки компании
        [HttpPost("update-company-card")]
        public async Task<IActionResult> UpdateCompanyCard(Guid companyId, [FromBody] CompanyCardUpdateData cardData)
        {
            try
            {
                var company = await _context.Companies
                    .Include(c => c.CompanyCard)
                    .FirstOrDefaultAsync(c => c.Id == companyId);

                if (company == null)
                {
                    return NotFound($"Компания с ID {companyId} не найдена");
                }

                if (company.CompanyCard == null)
                {
                    return NotFound($"Карточка компании для компании {companyId} не найдена");
                }

                // Обновляем данные карточки
                company.CompanyCard.DirectorFullName = cardData.DirectorFullName;
                company.CompanyCard.SertificateGRUL = cardData.SertificateGRUL;
                company.CompanyCard.Post = cardData.Post;
                company.CompanyCard.Address = cardData.Address;
                company.CompanyCard.Email = cardData.Email;
                company.CompanyCard.Site = cardData.Site;
                company.CompanyCard.LocationLink = cardData.LocationLink;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Карточка компании успешно обновлена" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }
    }
} 