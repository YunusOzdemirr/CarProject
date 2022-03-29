using System;
using AutoMapper;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;
using CarProject.Entities.Dtos.BusDtos;

namespace CarProject.Business.AutoMapper.Profiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<BusAddDto, Bus>().ReverseMap();
            CreateMap<BusUpdateDto, Bus>().ReverseMap();
        }
    }
}

