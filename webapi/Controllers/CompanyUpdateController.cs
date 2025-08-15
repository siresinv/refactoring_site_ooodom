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
    [Route("api/[controller]")]
    public class CompanyUpdateController : ControllerBase
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;

        public CompanyUpdateController(CompanyDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        // DTO для обновления компании с карточкой
        public class UpdateCompanyWithCardRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = null!;
            public string Shortname { get; set; } = null!;
            public CompanyCardUpdateData CompanyCard { get; set; } = null!;
        }

        public class CompanyCardUpdateData
        {
            //public Guid Id { get; set; }
            public Guid CompanyId { get; set; }

            public string DirectorFullName { get; set; } = null!;
            public string SertificateGRUL { get; set; } = null!;
            public string Post { get; set; } = null!;
            public string Address { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Site { get; set; } = null!;
            public string? LocationLink { get; set; }
            /////////////////////////////добавил свойства/////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////
            public ICollection<PhoneDTO> Phones { get; set; } = null!;
            public ICollection<WorkHourDTO> WorkHours { get; set; } = null!;
            public ICollection<ReceptionDTO> Receptions { get; set; } = null!;


        }





        ////////////////////////////3 classes - уже в юзинге//////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////


        // POST метод для обновления компании и связанной карточки
        [HttpPost("update-company-with-card")]
        public async Task<IActionResult> UpdateCompanyWithCard([FromBody] UpdateCompanyWithCardRequest request)
        {
            try
            {
                // Находим компанию с включенной карточкой
                ///////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////
                var company = await _context.Companies
                    .Include(c => c.CompanyCard)
                        .ThenInclude(cc => cc!.Phones)
                    .Include(c => c.CompanyCard)
                        .ThenInclude(cc => cc!.Receptions)
                    .Include(c => c.CompanyCard)
                        .ThenInclude(cc => cc!.WorkHours)

                    .FirstOrDefaultAsync(c => c.Id == request.Id)
                    ;
                Console.WriteLine();
                Console.WriteLine(company?.Id);
                Console.WriteLine();

                if (company == null)
                {
                    return NotFound($"Компания с ID {request.Id} не найдена");
                }

                // Обновляем данные компании
                company.Name = request.Name;
                company.Shortname = request.Shortname;

                // Обновляем или создаем карточку компании
                if (company.CompanyCard == null)
                {
                    // Создаем новую карточку, если её нет
                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!////////////////////создаются еще сущности//////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
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

                    Console.WriteLine();
                    Console.WriteLine(company.Id);
                    Console.WriteLine();


                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////
                    if (company.CompanyCard.Phones == null)
                    {
                        company.CompanyCard.Phones = new List<Phone>();
                        var phonesDTO = request.CompanyCard.Phones;
                        foreach (var phoneDTO in phonesDTO)
                        {
                            var phone = _mapper.Map<Phone>(phoneDTO);
                            company.CompanyCard.Phones.Add(phone);
                        }
                        
                        
                        

                        //company.CompanyCard.Phones = request.CompanyCard.Phones.ToList();

                        /*company.CompanyCard.Phones = new List<Phone>
                        {
                            new Phone
                            {
                                //Id = Guid.NewGuid(),
                                Name = "dfgdsg",
                                Value = "sdfdsf",
                                CompanyCardId = company.CompanyCard.Id
                            },

                            new Phone
                            {
                                //Id = Guid.NewGuid(),
                                Name = "dfgdsg",
                                Value = "sdfdsf",
                                CompanyCardId = company.CompanyCard.Id
                            }
                        };*/

                        Console.WriteLine();
                        Console.WriteLine($"!!! - {company.CompanyCard.CompanyId}");
                        Console.WriteLine();
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

                    /*if (company.CompanyCard.WorkHours == null)
                    {

                        var workhours = _mapper.Map<WorkHour>(request.CompanyCard.WorkHours);
                        company.CompanyCard.WorkHours.Add(workhours);

                        *//*company.CompanyCard.WorkHours = new List<WorkHour>
                        {
                            new WorkHour
                            {
                                //Id = Guid.NewGuid(),
                                Name = "dfgdsg",
                                Value = "sdfdsf",
                                CompanyCardId = company.CompanyCard.Id
                            },

                            new WorkHour
                            {
                                //Id = Guid.NewGuid(),
                                Name = "dfgdsg",
                                Value = "sdfdsf",
                                CompanyCardId = company.CompanyCard.Id

                            }
                        };*//*
                    }*/




                    

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
                            /*if (company.CompanyCard.Receptions == null)
                            {
                                var receptions = _mapper.Map<Reception>(request.CompanyCard.Receptions);
                                company.CompanyCard.Receptions.Add(receptions);

                                *//*company.CompanyCard.Receptions = new List<Reception>
                                {
                                    new Reception
                                    {
                                        //Id = Guid.NewGuid(),
                                        Name = "dfgdsg",
                                        Value = "sdfdsf",
                                        CompanyCardId = company.CompanyCard.Id

                                    },

                                    new Reception
                                    {
                                        //Id = Guid.NewGuid(),
                                        Name = "dfgdsg",
                                        Value = "sdfdsf",
                                        CompanyCardId = company.CompanyCard.Id

                                    }
                                };*//*
                            }*/

                            //////////////////////////////////////////////////////////
                            //////////////////////////////////////////////////////////
                            //////////////////////////////////////////////////////////
                            //////////////////////////////////////////////////////////


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