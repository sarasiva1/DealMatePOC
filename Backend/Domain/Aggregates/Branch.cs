namespace DealMate.Backend.Domain.Aggregates;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DealerId { get; set; }

    // Navigation property
    public Dealer Dealer { get; set; } = null!;
}
