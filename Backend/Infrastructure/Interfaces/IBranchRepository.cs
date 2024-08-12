using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IBranchRepository
{
    Task<Branch> Create(Branch branch);
    Task<Branch> Update(Branch branch);
    Task<Branch> Delete(int id);
}
