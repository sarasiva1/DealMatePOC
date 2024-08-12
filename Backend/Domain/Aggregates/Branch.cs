﻿using DealMate.Backend.Service;

namespace DealMate.Backend.Domain.Aggregates;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DealerId { get; set; }

    [Include]
    public Dealer? Dealer { get; set; } 
}
