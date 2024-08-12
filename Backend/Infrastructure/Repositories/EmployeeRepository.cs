using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.DB;
using DealMate.Backend.Infrastructure.Interfaces;
using DealMate.Backend.Service.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DealMate.Backend.Infrastructure.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IRepository<Employee> repository;
        private readonly IRepository<Branch> branchRepository;
        private readonly IRepository<Role> roleRepository;
        public EmployeeRepository(IRepository<Employee> repository, IRepository<Branch> branchRepository
            , IRepository<Role> roleRepository)
        {
            this.repository = repository;
            this.branchRepository = branchRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var existEmployee = await repository.FindAsync(x => x.Email == employee.Email);
            if (existEmployee.Any())
            {
                throw new Exception($"The Employee Email {employee.Name} was already exist");
            }
            var branch = await branchRepository.GetByIdAsync(employee.BranchId);
            if(branch == null)
            {
                throw new Exception($"The BranchID {employee.BranchId} not exist");
            }
            var role = await roleRepository.GetByIdAsync(employee.RoleId);
            if (role == null)
            {
                throw new Exception($"The RoleID {employee.RoleId} not exist");
            }
            employee = await repository.AddAsync(employee);
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            var existEmployee = await repository.GetByIdAsync(employee.Id);
            if (existEmployee == null)
            {
                throw new Exception($"The EmployeeID {employee.Id} not exist");
            }
            existEmployee.Name = existEmployee.Name != employee.Name? employee.Name: existEmployee.Name;
            existEmployee.Password = existEmployee.Password != employee.Password ? employee.Password : existEmployee.Password;
            if(existEmployee.BranchId != employee.BranchId)
            {
                var branch = await branchRepository.GetByIdAsync(employee.BranchId);
                if (branch == null)
                {
                    throw new Exception($"The BranchID {employee.BranchId} not exist");
                }
                existEmployee.BranchId = branch.Id;
            }
            if (existEmployee.RoleId != employee.RoleId)
            {
                var role = await roleRepository.GetByIdAsync(employee.RoleId);
                if (role == null)
                {
                    throw new Exception($"The RoleId {employee.RoleId} not exist");
                }
                existEmployee.RoleId = role.Id;
            }

            existEmployee = await repository.Update(existEmployee);
            return existEmployee;
        }

        public async Task<Employee> Delete(int id)
        {
            var employee = await repository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception($"The Employee Id:{id} was not found");
            }
            employee = await repository.Remove(employee);
            return employee;
        }

    }
}
