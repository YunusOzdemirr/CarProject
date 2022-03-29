using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Business.ValidationRules.FluentValidation.BoatValidator;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BoatDtos;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Results.Concrete;
using CarProject.Shared.Utilities.Exceptions;
using CarProject.Shared.Utilities.Results.Abstract;
using CarProject.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Business.Concrete
{
    public class BoatManager : ManagerBase, IBoatService
    {
        public BoatManager(Context dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IDataResult> AddAsync(BoatAddDto boatAddDto)
        {
            ValidationTool.Validate(new BoatAddValidator(), boatAddDto);
            var boat = Mapper.Map<Boat>(boatAddDto);
            var boatIsExist = await Context.Boats.SingleOrDefaultAsync(a => a.Name == boat.Name);
            if (boatIsExist != null)
                throw new Exception("Bu isimde başka bir tekne mevcut.");
            boat.CreatedDate = DateTime.Now;
            await Context.Boats.AddAsync(boat);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"{boat.Name} adlı tekne eklenmiştir.", boat);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            var boat = await Context.Boats.SingleOrDefaultAsync(a => a.Id == id);
            if (boat is not null)
                throw new NotFoundArgumentException("Böyle bir tekne bulunmamakta", new Error("Not Found", "Id"));
            boat.IsActive = false;
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Tekne başarıyla silindi.");
        }

        public async Task<IDataResult> GetAllAsync(bool? isActive)
        {
            IQueryable<Boat> query = Context.Set<Boat>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByColor(string color)
        {
            IQueryable<Boat> query = Context.Set<Boat>();
            query = query.Where(a => a.Color == color);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var boat = await Context.Boats.SingleOrDefaultAsync(a => a.Id == id);
            if (boat is null)
                throw new NotFoundArgumentException("Böyle bir tekne bulunamadı.", new Error("Not Found", "Id"));

            return new DataResult(ResultStatus.Success, boat);
        }

        public async Task<IDataResult> UpdateAsync(BoatUpdateDto boatUpdateDto)
        {
            ValidationTool.Validate(new BoatUpdateValidator(), boatUpdateDto);
            var boatIsExist = await Context.Boats.SingleOrDefaultAsync(a => a.Id == boatUpdateDto.Id);
            if (boatIsExist is null)
                throw new NotFoundArgumentException("Böyle bir tekne bulunamadı", new Error("Not Found", "Id"));

            var boat = Mapper.Map<Boat>(boatUpdateDto);
            boat.ModifiedDate = DateTime.Now;
            Context.Boats.Update(boat);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, boat);

        }
    }
}

