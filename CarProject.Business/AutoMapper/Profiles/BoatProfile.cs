using System;
using AutoMapper;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BoatDtos;

namespace CarProject.Business.AutoMapper.Profiles
{
    public class BoatProfile : Profile
    {
        public BoatProfile()
        {
            CreateMap<BoatAddDto, Boat>().ReverseMap();
            CreateMap<BoatUpdateDto, Boat>().ReverseMap();
        }
    }
}

