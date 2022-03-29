using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarProject.Business.Abstract;
using CarProject.Entities.Dtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync(BrandAddDto brandAddDto)
        {
            var result = await _brandService.AddAsync(brandAddDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int brandId)
        {
            var result = await _brandService.GetByIdAsync(brandId);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _brandService.GetByName(name);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool isActive = true)
        {
            var result = await _brandService.GetAllAsync(isActive);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync(BrandUpdateDto brandUpdateDto)
        {
            var result = await _brandService.UpdateAsync(brandUpdateDto);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

