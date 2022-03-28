using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IBoatService
    {
        Task<IDataResult> AddAsync(Boat boat);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByColor(string color);
        Task<IDataResult> GetAllAsync();
        Task<IDataResult> UpdateAsync(Boat boat);
        Task<IDataResult> DeleteAsync(int id);
    }
}

