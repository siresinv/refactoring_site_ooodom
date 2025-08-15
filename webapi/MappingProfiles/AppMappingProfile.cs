using DBContext.DTO;
using DBContext.Entities;

using AutoMapper;


namespace webapi.MappingProfiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CompanyCard, CompanyCardDTO>();
            CreateMap<CompanyCard, CompanyCardDTO>().ReverseMap();
            CreateMap<Phone, PhoneDTO>();
            CreateMap<Phone, PhoneDTO>().ReverseMap();
            CreateMap<WorkHour, WorkHourDTO>();
            CreateMap<WorkHour, WorkHourDTO>().ReverseMap();
            CreateMap<Reception, ReceptionDTO>();
            CreateMap<Reception, ReceptionDTO>().ReverseMap();

            //CreateMap<List<Phone>, List<PhoneDTO>>();
            //CreateMap<List<Phone>, List<PhoneDTO>>().ReverseMap();

        }
    }
}
