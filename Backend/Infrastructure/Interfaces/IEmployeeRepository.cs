using DealMate.Backend.Domain.Aggregates;
using System.Security.Claims;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> Create(Employee employee);
    Task<Employee> Update(Employee employee);
    Task<Employee> Delete(int id);
    Task<string> LogIn(string email, string password);
    Task<Employee> ChangePassword(string email, string password);
}
