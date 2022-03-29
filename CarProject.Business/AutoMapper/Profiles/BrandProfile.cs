using System;
using AutoMapper;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;

namespace CarProject.Business.AutoMapper.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandAddDto, Brand>().ReverseMap();
            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
        }
    }
}

