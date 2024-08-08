using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IBranchRepository
{
    Task<List<Branch>> List();
    Task<Branch> Create(Branch branch);
    Task<Branch> Get(int id);
    Task<Branch> Update(Branch branch);
    Task<Branch> Delete(int id);
}
