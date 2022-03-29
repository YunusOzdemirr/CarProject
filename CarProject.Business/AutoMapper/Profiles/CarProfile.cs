using System;
using AutoMapper;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.CarDtos;

namespace CarProject.Business.AutoMapper.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarAddDto, Car>().ReverseMap();
            CreateMap<CarUpdateDto, Car>().ReverseMap();
        }
    }
}

