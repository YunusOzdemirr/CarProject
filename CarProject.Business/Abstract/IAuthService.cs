using System;
using System.Threading.Tasks;
using CarProject.Entities.Dtos.AuthDtos;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<IDataResult> LoginAsync(UserLoginDto userLoginDto);
        //Task<bool> UserExistsAsync(string emailAddress);
    }
}

