using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BusDtos;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IBusService
    {
        Task<IDataResult> AddAsync(BusAddDto busAddDto);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByColor(string color);
        Task<IDataResult> GetAllAsync(bool? isActive);
        Task<IDataResult> UpdateAsync(BusUpdateDto busUpdateDto);
        Task<IDataResult> DeleteAsync(int id);
    }
}

