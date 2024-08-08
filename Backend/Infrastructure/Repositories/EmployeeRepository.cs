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
        private readonly ApplicationDbContext db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var alreadyExist = await db.Employee.FirstOrDefaultAsync(_ => _.Email == employee.Email);
            if (alreadyExist != null)
            {
                throw new Exception($"The Emai:{employee.Email} already exists");
            }
            
            await db.Employee.AddAsync(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            var alreadyExist = await db.Employee.FirstOrDefaultAsync(_ => _.Id == employee.Id);
            if (alreadyExist == null)
            {
                throw new Exception($"The Employee Id:{employee.Id} was not found");
            }
            alreadyExist.Name = alreadyExist.Name != employee.Name ? employee.Name : alreadyExist.Name;
            alreadyExist.Email = alreadyExist.Email != employee.Email ? employee.Email : alreadyExist.Email;
            alreadyExist.Password = alreadyExist.Password != employee.Password ? employee.Password : alreadyExist.Password;
            
            await db.SaveChangesAsync();
            return alreadyExist;
        }

        public async Task<Employee> Delete(int id)
        {
            var employee = await db.Employee.FirstOrDefaultAsync(_ => _.Id == id);
            if (employee == null)
            {
                throw new Exception($"The Employee Id:{id} was not found");
            }

            db.Employee.Remove(employee);
            await db.SaveChangesAsync();
            return employee;
        }

    }
}
