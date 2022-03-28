using System;
using System.Threading.Tasks;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Abstract
{
    public interface IVehicleService
    {
        Task<IDataResult> GetVehiclesByColor(string color);
        Task<IDataResult> GetAllVehiclesAsync();
    }
}

