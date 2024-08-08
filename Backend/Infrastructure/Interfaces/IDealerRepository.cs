using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Infrastructure.Interfaces;

public interface IDealerRepository
{
    Task<List<Dealer>> List();
    Task<Dealer> Create(Dealer dealer);
    Task<Dealer> Get(int id);
    Task<Dealer> Update(Dealer dealer);
    Task<Dealer> Delete(int id);
}
