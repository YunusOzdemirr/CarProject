using System;
using System.Threading.Tasks;
using CarProject.Entities.Concrete;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult> AddAsync(Brand brand);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByName(string name);
        Task<IDataResult> GetAllAsync();
        Task<IDataResult> UpdateAsync(Brand brand);
        Task<IDataResult> DeleteAsync(int id);
    }
}

