using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.CarDtos;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult> AddAsync(CarAddDto car);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByColor(string color);
        Task<IDataResult> GetAllAsync(bool? isActive);
        Task<IDataResult> UpdateAsync(Car car);
        Task<IDataResult> DeleteAsync(int id);
        Task<IDataResult> HardDeleteAsync(int id);
    }
}

