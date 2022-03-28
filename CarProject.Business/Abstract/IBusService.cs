using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IBusService
    {
        Task<IDataResult> AddAsync(Bus bus);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByColor(string color);
        Task<IDataResult> GetAllAsync();
        Task<IDataResult> UpdateAsync(Bus bus);
        Task<IDataResult> DeleteAsync(int id);
    }
}

