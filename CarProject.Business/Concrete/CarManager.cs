using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Business.ValidationRules.FluentValidation.CarValidator;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Results.Concrete;
using CarProject.Shared.Utilities.Exceptions;
using CarProject.Shared.Utilities.Results.Abstract;
using CarProject.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Business.Concrete
{
    public class CarManager : ManagerBase, ICarService
    {
        public CarManager(Context dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IDataResult> AddAsync(Car car)
        {
            ValidationTool.Validate(new CarAddValidator(), car);
            var isExist = await Context.Cars.SingleOrDefaultAsync(a => a.Name == car.Name);
            if (isExist is not null)
                throw new Exception("Bu Araç Mevcut");

            await Context.Cars.AddAsync(car);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, car);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            var car = await Context.Cars.SingleOrDefaultAsync(a => a.Id == id);
            if (car is null)
                throw new NotFoundArgumentException("Böyle bir araba bulunmamakta", new Error());
            car.IsActive = false;
            // Context.Cars.Remove(car);
            Context.Cars.Update(car);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, car.Name + " adlı araba başarıyla silindi");
        }
        public async Task<IDataResult> HardDeleteAsync(int id)
        {
            var car = await Context.Cars.SingleOrDefaultAsync(a => a.Id == id);
            if (car is null)
                throw new NotFoundArgumentException("Böyle bir araba bulunmamakta", new Error());
            Context.Cars.Remove(car);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, car.Name + " adlı araba başarıyla kalıcı olarak silindi");
        }

        public async Task<IDataResult> GetAllAsync(bool? isActive)
        {
            IQueryable<Car> query = Context.Set<Car>();
            if (isActive.HasValue) query.Where(a => a.IsActive == isActive);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                var cars = Context.Cars.Where(a => a.Color == color);
                return new DataResult(ResultStatus.Success, cars);
            }
            return new DataResult(ResultStatus.Warning, "Bu Renkte araba bulunmamaktadır");
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var car = await Context.Cars.SingleOrDefaultAsync(a => a.Id == id);
            return new DataResult(ResultStatus.Success, car);
        }

        public async Task<IDataResult> UpdateAsync(Car car)
        {
            ValidationTool.Validate(new CarUpdateValidator(), car);

            Context.Cars.Update(car);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, car.Name + " adlı araba başarıyla güncellendi");
        }
    }
}

