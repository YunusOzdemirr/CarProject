using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarProject.Business.Abstract;
using CarProject.Entities.Concrete;
using CarProject.Entities.Dtos.CarDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync(CarAddDto carAddDto)
        {
            var result = await _carService.AddAsync(carAddDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int carId)
        {
            var result = await _carService.GetByIdAsync(carId);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByColor(string color)
        {
            var result = await _carService.GetByColor(color);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool isActive = true)
        {
            var result = await _carService.GetAllAsync(isActive);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync(CarUpdateDto carUpdateDto)
        {
            var result = await _carService.UpdateAsync(carUpdateDto);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carService.DeleteAsync(id);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _carService.HardDeleteAsync(id);
            return Ok(result);
        }
    }
}

