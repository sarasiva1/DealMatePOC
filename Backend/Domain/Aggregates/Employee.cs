using DealMate.Backend.Service;

namespace DealMate.Backend.Domain.Aggregates;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int BranchId { get; set; }
    [Include]
    public Branch? Branch { get; set; }
    public int RoleId { get; set; }
    [Include]
    public Role? Role { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
