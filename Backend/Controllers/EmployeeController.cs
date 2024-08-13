using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.Interfaces;
using DealMate.Backend.Service.Common;
using DealMate.Backend.Service.ExcelProcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DealMate.Backend.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IRepository<Employee> repository;
        private readonly IExcelService excelService;
        public EmployeeController(IEmployeeRepository employeeRepository, IRepository<Employee> repository,
            IExcelService excelService)
        {
            this.employeeRepository = employeeRepository;
            this.repository = repository;
            this.excelService = excelService;
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

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            return Ok(await employeeRepository.Create(employee));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            return Ok(await employeeRepository.Update(employee));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await employeeRepository.Delete(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            return Ok(await employeeRepository.LogIn(email, password));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UploadFileFromDevice(IFormFile file)
        {
            return Ok(this.excelService.VehicleProcess(file));
        }

    }
    
}
