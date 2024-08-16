using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.Interfaces;
using DealMate.Backend.Service.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DealMate.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository branchRepository;
        private readonly IRepository<Branch> repository;
        public BranchController(IBranchRepository branchRepository, IRepository<Branch> repository)
        {
            this.branchRepository = branchRepository;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await repository.ListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Branch branch)
        {
            return Ok(await branchRepository.Create(branch));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Branch branch)
        {
            return Ok(await branchRepository.Update(branch));
        }

        

    }
}
