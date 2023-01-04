using AutoMapper;
using dotnetcore_7.Dto;
using dotnetcore_7.Model;

namespace dotnetcore_7.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserGetAllDto>().ReverseMap();
        CreateMap<User, UserGetAllRankingDto>()
            .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => (new Random()).Next(1, 10001)))
            .ReverseMap();
    }   
}