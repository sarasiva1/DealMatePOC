using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DealMate.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IRepository<Employee> repository;
        public EmployeeController(IEmployeeRepository employeeRepository, IRepository<Employee> repository)
        {
            this.employeeRepository = employeeRepository;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
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
    }
}
