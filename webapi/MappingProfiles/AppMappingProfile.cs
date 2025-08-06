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
        }
    }
}
