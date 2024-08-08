using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IDealerRepository
{
    Task<Dealer> Create(Dealer dealer);
    Task<Dealer> Update(Dealer dealer);
    Task<Dealer> Delete(int id);
}
