using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Business.ValidationRules.FluentValidation.BusValidator;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BusDtos;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Results.Concrete;
using CarProject.Shared.Utilities.Exceptions;
using CarProject.Shared.Utilities.Results.Abstract;
using CarProject.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Business.Concrete
{
    public class BusManager : ManagerBase, IBusService
    {
        public BusManager(Context dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IDataResult> AddAsync(BusAddDto busAddDto)
        {
            ValidationTool.Validate(new BusAddDtoValidator(), busAddDto);
            var bus = Mapper.Map<Bus>(busAddDto);
            var isExist = await Context.Buses.SingleOrDefaultAsync(a => a.Name == bus.Name);
            if (isExist is not null)
                throw new Exception("Böyle bir otobüs bulunmaktadır");
            bus.CreatedDate = DateTime.Now;
            await Context.Buses.AddAsync(bus);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, busAddDto);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            var bus = await Context.Buses.SingleOrDefaultAsync(a => a.Id == id);
            if (bus is null)
                throw new NotFoundArgumentException("Böyle bir otobüs bulunamadı.", new Error("Not Found", "Id"));

            bus.IsActive = false;
            Context.Buses.Update(bus);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"{bus.Name} başarıyla silindi");
        }

        public async Task<IDataResult> GetAllAsync(bool? isActive)
        {
            IQueryable<Bus> query = Context.Set<Bus>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByColor(string color)
        {
            IQueryable<Bus> query = Context.Set<Bus>().AsNoTracking();
            query = query.Where(a => a.Color == color);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var bus = await Context.Buses.SingleOrDefaultAsync(a => a.Id == id);
            if (bus is null)
                throw new NotFoundArgumentException("Böyle bir otobüs bulunamadı", new Error("Not Found", "Id"));

            return new DataResult(ResultStatus.Success, bus);
        }

        public async Task<IDataResult> HardDeleteAsync(int id)
        {
            var bus = await Context.Buses.SingleOrDefaultAsync(a => a.Id == id);
            if (bus is null)
                throw new NotFoundArgumentException("Böyle bir otobüs bulunamadı.", new Error("Not Found", "Id"));

            Context.Buses.Remove(bus);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"{bus.Name} başarıyla kalıcı olarak silindi");
        }

        public async Task<IDataResult> UpdateAsync(BusUpdateDto busUpdateDto)
        {
            ValidationTool.Validate(new BusUpdateValidator(), busUpdateDto);
            var bus = Mapper.Map<Bus>(busUpdateDto);
            if (!await Context.Buses.AnyAsync(a => a.Id == bus.Id))
                throw new NotFoundArgumentException("Böyle bir otobüs bulunamadı", new Error("Not Found", "Id"));

            bus.ModifiedDate = DateTime.Now;
            Context.Buses.Update(bus);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, bus);

        }
    }
}

