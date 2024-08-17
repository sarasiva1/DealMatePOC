using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.Interfaces;
using DealMate.Backend.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DealMate.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;       
        private readonly IRepository<Vehicle> repository;

        public VehicleController(IVehicleRepository vehicleRepository, IRepository<Vehicle> repository)
        {
            this.vehicleRepository = vehicleRepository;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await repository.ListAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Vehicle vehicle)
        {
            return Ok(await vehicleRepository.Update(vehicle));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await vehicleRepository.Delete(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            return Ok(await vehicleRepository.ExcelUpload(file));
        }
    }
}
