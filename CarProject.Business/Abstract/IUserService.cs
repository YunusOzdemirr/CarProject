using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult> AddAsync(User user);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetAllAsync();
        Task<IDataResult> UpdateAsync(User user);
        Task<IDataResult> DeleteAsync(int id);
    }
}

