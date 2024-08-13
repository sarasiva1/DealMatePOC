using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Service.Enforcer;

public interface IEnforcer
{
    Task EnforceAsync(string permission);
}
