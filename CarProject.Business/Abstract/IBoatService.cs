using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BoatDtos;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IBoatService
    {
        Task<IDataResult> AddAsync(BoatAddDto boatAddDto);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByColor(string color);
        Task<IDataResult> GetAllAsync(bool? isActive);
        Task<IDataResult> UpdateAsync(BoatUpdateDto boatUpdateDto);
        Task<IDataResult> DeleteAsync(int id);
    }
}

