using AutoMapper;
using llbltest.Dtos;
using llbltest.EntityClasses;

namespace llbltest.API.AutoMapperProfiles
{
    public class DealerAutoMapperProfile : Profile
    {
        public DealerAutoMapperProfile()
        {
            CreateMap<Dealer, DealerDto>().ReverseMap();
        }
    }
} 