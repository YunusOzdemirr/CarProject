using System;
using AutoMapper;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;

namespace CarProject.Business.AutoMapper.Profiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<BrandAddDto, Brand>().ReverseMap();
            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
        }
    }
}

