using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Project_C.Models;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Project_C.Data
{
    public class CustomRoleStore : IRoleStore<Role>
    {
		public ApplicationDbContext DbContext { get; set; }

		public CustomRoleStore(ApplicationDbContext dbContext)
		{
            DbContext = dbContext;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            await DbContext.AddAsync(role, cancellationToken);
			return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            EntityEntry<Role> entry = DbContext.Remove(role);
			await DbContext.SaveChangesAsync(cancellationToken);
			if (entry.State == EntityState.Detached)
				return IdentityResult.Failed();
			return IdentityResult.Success;
        }

        public void Dispose()
        {
            // Do nothing
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            int.TryParse(roleId, out int id);
            return await DbContext.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            normalizedRoleName = normalizedRoleName.ToLower();
            return await DbContext.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == normalizedRoleName, cancellationToken);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
            => GetRoleNameAsync(role, cancellationToken);

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id.ToString());

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
            => Task.CompletedTask;

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
			EntityEntry<Role> entry = DbContext.Update(role);
			await DbContext.SaveChangesAsync(cancellationToken);
			if (entry.State == EntityState.Detached)
				return IdentityResult.Failed();
			return IdentityResult.Success;
        }
    }
}
