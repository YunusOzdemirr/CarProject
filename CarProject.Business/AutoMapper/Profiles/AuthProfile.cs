using System;
using AutoMapper;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.AuthDtos;
using CarProject.Shared.Utilities.Security.Jwt;

namespace CarProject.Business.AutoMapper.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserRegisterDto, User>().ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();
            CreateMap<UserToken, AccessToken>().ReverseMap();
        }
    }
}

