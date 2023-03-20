using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;

namespace Cars.Application.Mapper.Salesman;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SalesmanDto, SalesmanEntity>().ReverseMap();
    }
}