using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarProject.Business.Abstract;
using CarProject.Business.ValidationRules.FluentValidation.BrandValidator;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.BrandDtos;
using CarProject.Shared.Entities.Concrete;
using CarProject.Shared.Results.ComplexTypes;
using CarProject.Shared.Results.Concrete;
using CarProject.Shared.Utilities.Exceptions;
using CarProject.Shared.Utilities.Results.Abstract;
using CarProject.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Business.Concrete
{
    public class BrandManager : ManagerBase, IBrandService
    {
        public BrandManager(Context dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IDataResult> AddAsync(BrandAddDto brandAddDto)
        {
            ValidationTool.Validate(new BrandAddDtoValidator(), brandAddDto);
            var isExistBrand = await Context.Brands.SingleOrDefaultAsync(a => a.Name == brandAddDto.Name);
            if (isExistBrand is not null)
                throw new Exception("Böyle bir marka adı bulunmaktadır.");
            var brand = Mapper.Map<Brand>(brandAddDto);
            brand.CreatedDate = DateTime.Now;
            await Context.Brands.AddAsync(brand);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, brand);
        }

        public async Task<IDataResult> DeleteAsync(int id)
        {
            var brand = await Context.Brands.SingleOrDefaultAsync(a => a.Id == id);
            if (brand is null)
                throw new NotFoundArgumentException("Böyle bir marka bulunmamaktadır", new Error("Not Found", "Id"));
            brand.IsActive = false;
            Context.Brands.Update(brand);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"{brand.Name} adlı marka başarıyla silindi.");
        }

        public async Task<IDataResult> GetAllAsync(bool? isActive)
        {
            IQueryable<Brand> query = Context.Set<Brand>();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var brand = await Context.Brands.SingleOrDefaultAsync(a => a.Id == id);
            if (brand is null)
                throw new NotFoundArgumentException("Böyle bir marka bulunmamaktadır.", new Error("Not Found", "Id"));

            return new DataResult(ResultStatus.Success, brand);
        }

        public async Task<IDataResult> GetByName(string name)
        {
            var brand = await Context.Brands.SingleOrDefaultAsync(a => a.Name == name);
            if (brand is null)
                throw new NotFoundArgumentException("Böyle bir marka bulunmamaktadır.", new Error("Not Found", "Name"));

            return new DataResult(ResultStatus.Success, brand);
        }
        public async Task<IDataResult> HardDeleteAsync(int id)
        {
            var brand = await Context.Brands.SingleOrDefaultAsync(a => a.Id == id);
            if (brand is null)
                throw new NotFoundArgumentException("Böyle bir marka bulunmamakta", new Error("Not Found", "Id"));
            Context.Brands.Remove(brand);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"{brand.Name} başarıyla silindi.");
        }

        public async Task<IDataResult> UpdateAsync(BrandUpdateDto brandUpdateDto)
        {
            ValidationTool.Validate(new BrandUpdateDtoValidator(), brandUpdateDto);
            var brandIsExist = await Context.Brands.SingleOrDefaultAsync(a => a.Id == brandUpdateDto.Id);
            if (brandIsExist is null)
                throw new NotFoundArgumentException("Böyle bir marka bulunamadı", new Error("Not Found", "Id"));

            var brand = Mapper.Map<BrandUpdateDto, Brand>(brandUpdateDto, brandIsExist);
            brand.ModifiedDate = DateTime.Now;
            Context.Brands.Update(brand);
            await Context.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, brand);
        }
    }
}

