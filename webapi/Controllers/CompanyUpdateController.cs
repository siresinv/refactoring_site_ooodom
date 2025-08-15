using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Entities;
using DBContext.DTO;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/{id}")]
    public class CompanyUpdateController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;

        public CompanyUpdateController(CompanyDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

       
        // POST метод для обновления компании и связанной карточки
        [HttpPost("update-company-with-card")]
        public async Task<IActionResult> UpdateCompanyWithCard([FromBody] CompanyDTO request, [FromRoute] Guid id)
        {
            try
            {
                var company = await _context.Companies
                    .Include(c => c.CompanyCard)
                        .ThenInclude(cc => cc!.Phones)
                    .Include(c => c.CompanyCard)
                        .ThenInclude(cc => cc!.Receptions)
                    .Include(c => c.CompanyCard)
                        .ThenInclude(cc => cc!.WorkHours)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (company == null)
                {
                    return NotFound($"Компания с ID {id} не найдена");
                }

                // Обновляем данные компании
                company.Name = request.Name;
                company.Shortname = request.Shortname;

                // Обновляем или создаем карточку компании
                if (company.CompanyCard == null)
                {
                    company.CompanyCard = new CompanyCard
                    {
                        //Id = Guid.NewGuid(),
                        CompanyId = company.Id,
                        DirectorFullName = request.CompanyCard.DirectorFullName,
                        SertificateGRUL = request.CompanyCard.SertificateGRUL,
                        Post = request.CompanyCard.Post,
                        Address = request.CompanyCard.Address,
                        Email = request.CompanyCard.Email,
                        Site = request.CompanyCard.Site,
                        LocationLink = request.CompanyCard.LocationLink
                    };


                    if (company.CompanyCard.Phones == null)
                    {
                        company.CompanyCard.Phones = new List<Phone>();
                        var phonesDTO = request.CompanyCard.Phones;
                        foreach (var phoneDTO in phonesDTO)
                        {
                            var phone = _mapper.Map<Phone>(phoneDTO);
                            company.CompanyCard.Phones.Add(phone);
                        }
                    }


                    if (company.CompanyCard.WorkHours == null)
                    {
                        company.CompanyCard.WorkHours = new List<WorkHour>();
                        var workhoursDTO = request.CompanyCard.WorkHours;
                        foreach (var workHourDTO in workhoursDTO)
                        {
                            var workHour = _mapper.Map<WorkHour>(workHourDTO);
                            company.CompanyCard.WorkHours.Add(workHour);
                        }
                    }

                                      

                    if (company.CompanyCard.Receptions == null)
                    {
                        company.CompanyCard.Receptions = new List<Reception>();
                        var receptionsDTO = request.CompanyCard.Receptions;
                        foreach(var receptionDTO in receptionsDTO)
                        {
                            var reception = _mapper.Map<Reception>(receptionDTO);
                            company.CompanyCard.Receptions.Add(reception);
                        }

                    }
                }
                else
                {
                    // Обновляем существующую карточку
                    /*company.CompanyCard.DirectorFullName = request.CompanyCard.DirectorFullName;
                    company.CompanyCard.SertificateGRUL = request.CompanyCard.SertificateGRUL;
                    company.CompanyCard.Post = request.CompanyCard.Post;
                    company.CompanyCard.Address = request.CompanyCard.Address;
                    company.CompanyCard.Email = request.CompanyCard.Email;
                    company.CompanyCard.Site = request.CompanyCard.Site;
                    company.CompanyCard.LocationLink = request.CompanyCard.LocationLink;*/
                }

                // Сохраняем изменения в базе данных
                await _context.SaveChangesAsync();

                // Возвращаем обновленные данные
                var result = new
                {

                    ///
                    //////
                    ///Company = company,
                    //////
                    ///

                    //CompanyCard = company.CompanyCard,

                    /*Company = new CompanyDTO
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
                    },*/

                    //Phones = company.CompanyCard.Phones.ToList(),
                    //Receptions = company.CompanyCard.Receptions.ToList(),
                    //WorkHours = company.CompanyCard.WorkHours.ToList()

                    
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
        public async Task<IActionResult> UpdateCompanyCard(Guid companyId, [FromBody] CompanyCardDTO cardData)
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