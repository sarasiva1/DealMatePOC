using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.DB;
using DealMate.Backend.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DealMate.Backend.Infrastructure.Repositories;

public class DealerRepository : IDealerRepository
{
    private readonly ApplicationDbContext db;
    public DealerRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task<List<Dealer>> List()
    {
        return await db.Dealers.ToListAsync();
    }

    public async Task<Dealer> Get(int id)
    {
        var dealer = await db.Dealers.FirstOrDefaultAsync(_ => _.Id == id);
        if (dealer == null)
        {
            throw new Exception($"The Dealer Id:{id} was not found");
        }
        return dealer;
    }

    public async Task<Dealer> Create(Dealer dealer)
    {
        var existDealer = await db.Dealers.FirstOrDefaultAsync(_ => _.Name == dealer.Name);
        if (existDealer != null)
        {
            throw new Exception($"The Dealer {dealer.Name} was already exist");
        }
        await db.AddAsync(dealer);
        await db.SaveChangesAsync();
        return dealer;
    }

    public async Task<Dealer> Update(Dealer dealer)
    {
        var existDealer = await db.Dealers.FirstOrDefaultAsync(_ => _.Name == dealer.Name);
        if (existDealer != null)
        {
            throw new Exception($"The Dealer {dealer.Name} was already exist");
        }
        await db.AddAsync(dealer);
        await db.SaveChangesAsync();
        return dealer;
    }

    public async Task<Dealer> Delete(int id)
    {
        var dealer = await db.Dealers.FirstOrDefaultAsync(_ => _.Id == id);
        if (dealer == null)
        {
            throw new Exception($"The Dealer Id:{id} was not found");
        }
        db.Dealers.Remove(dealer);
        await db.SaveChangesAsync();
        return dealer;
    }
}