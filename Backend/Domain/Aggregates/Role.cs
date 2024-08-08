namespace DealMate.Backend.Domain.Aggregates;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Types.Roles RoleType { get; set; }


    public static class Types
    {
        public enum Roles
        {
            Unspecified = 0,
            CRE = 1,
            FinalInspector = 2,
            ServiceAdvisor = 3,
            Security = 4
        }
    }
}
