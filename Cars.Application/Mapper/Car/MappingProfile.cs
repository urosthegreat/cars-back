using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;

namespace Cars.Application.Mapper.Car;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarDto, CarEntity>().ReverseMap();
    }
}