using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetAllVehiclesAsync()
        {
            var result = await _vehicleService.GetAllVehiclesAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(string color)
        {
            var result = await _vehicleService.GetVehiclesByColor(color);
            return Ok(result);
        }
    }
}

