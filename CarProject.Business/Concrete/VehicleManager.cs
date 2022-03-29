using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Results.Concrete;
using CarProject.Shared.Utilities.Results.Abstract;

namespace CarProject.Business.Concrete
{
    public class VehicleManager : ManagerBase, IVehicleService
    {
        public VehicleManager(Context dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IDataResult> GetAllVehiclesAsync()
        {
            IQueryable<Boat> boats = Context.Set<Boat>();
            IQueryable<Car> cars = Context.Set<Car>();
            IQueryable<Bus> buses = Context.Set<Bus>();
            return new DataResult(ResultStatus.Success, new { Boats = boats, Cars = cars, Buses = buses });
        }

        public async Task<IDataResult> GetVehiclesByColor(string color)
        {
            IQueryable<Boat> boats = Context.Set<Boat>();
            boats = boats.Where(a => a.Color == color);
            IQueryable<Car> cars = Context.Set<Car>();
            cars = cars.Where(a => a.Color == color);
            IQueryable<Bus> buses = Context.Set<Bus>();
            buses = buses.Where(a => a.Color == color);
            return new DataResult(ResultStatus.Success, new { Boats = boats, Cars = cars, Buses = buses });
        }
    }
}

