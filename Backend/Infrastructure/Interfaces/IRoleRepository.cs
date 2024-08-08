using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IRoleRepository
{
    Task<List<Role>> List();
    Task<Role> Create(Role role);
    Task<Role> Get(int id);
    Task<Role> Update(Role role);
    Task<Role> Delete(int id);
}
