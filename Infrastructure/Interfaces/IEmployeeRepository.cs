using DealMate.Domain.Aggregates;

namespace DealMate.Infrastructure.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> List();
    Task<Employee> Create(Employee employee);
    Task<Employee> Get(int id);
    Task<Employee> Update(Employee employee);
    Task<Employee> Delete(int id);
}
