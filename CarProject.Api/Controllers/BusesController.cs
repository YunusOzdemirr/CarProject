using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarProject.Business.Abstract;
using CarProject.Entities.Dtos.BusDtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class BusesController : Controller
    {
        private readonly IBusService _busService;

        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync(BusAddDto busAddDto)
        {
            var result = await _busService.AddAsync(busAddDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int busId)
        {
            var result = await _busService.GetByIdAsync(busId);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByColor(string color)
        {
            var result = await _busService.GetByColor(color);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool isActive = true)
        {
            var result = await _busService.GetAllAsync(isActive);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync(BusUpdateDto busUpdateDto)
        {
            var result = await _busService.UpdateAsync(busUpdateDto);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _busService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

