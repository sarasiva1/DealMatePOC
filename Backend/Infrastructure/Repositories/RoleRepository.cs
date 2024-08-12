using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.Interfaces;

namespace DealMate.Backend.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRepository<Role> repository;
        public RoleRepository(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        public async Task<Role> Create(Role role)
        {
            var existRole = await repository.FindAsync(x => x.Name == role.Name);
            if (existRole.Any())
            {
                throw new Exception($"The Role {role.Name} was already exist");
            }
            role = await repository.AddAsync(role);
            return role;
        }

        public async Task<Role> Update(Role role)
        {
            var existRole = await repository.GetByIdAsync(role.Id);
            if (existRole == null)
            {
                throw new Exception($"The RoleID {role.Id} not exist");
            }
            existRole.Name = role.Name;
            existRole = await repository.Update(existRole);
            return existRole;
        }

        public async Task<Role> Delete(int id)
        {
            var role = await repository.GetByIdAsync(id);
            if (role == null)
            {
                throw new Exception($"The Role Id:{id} was not found");
            }
            role = await repository.Remove(role);
            return role;
        }

    }
}
