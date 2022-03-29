using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult> AddAsync(BrandAddDto brandAddDto);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByName(string name);
        Task<IDataResult> GetAllAsync(bool? isActive);
        Task<IDataResult> UpdateAsync(BrandUpdateDto brandAddDto);
        Task<IDataResult> DeleteAsync(int id);
        Task<IDataResult> HardDeleteAsync(int id);
    }
}

