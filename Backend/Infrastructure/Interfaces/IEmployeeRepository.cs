using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> Create(Employee employee);
    Task<Employee> Update(Employee employee);
    Task<Employee> Delete(int id);
}
