using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarProject.Business.Abstract;
using CarProject.Entities.Dtos.BoatDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BoatsController : Controller
    {
        private readonly IBoatService _boatService;

        public BoatsController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAsync(BoatAddDto boatAddDto)
        {
            var result = await _boatService.AddAsync(boatAddDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int boatId)
        {
            var result = await _boatService.GetByIdAsync(boatId);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByColor(string color)
        {
            var result = await _boatService.GetByColor(color);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool isActive = true)
        {
            var result = await _boatService.GetAllAsync(isActive);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync(BoatUpdateDto boatUpdateDto)
        {
            var result = await _boatService.UpdateAsync(boatUpdateDto);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _boatService.DeleteAsync(id);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _boatService.HardDeleteAsync(id);
            return Ok(result);
        }
    }
}

