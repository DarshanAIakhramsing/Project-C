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

        //makes connection with the database
		public CustomRoleStore(ApplicationDbContext dbContext)
		{
            DbContext = dbContext;
        }

        //Adds a role to the database
        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            await DbContext.AddAsync(role, cancellationToken);
			return IdentityResult.Success;
        }
        
        //Removes the role 
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

        //Makes sure a role can be found
        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            int.TryParse(roleId, out int id);
            return await DbContext.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        //Makes sure to make the role name lower case when getting it from the database
        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            normalizedRoleName = normalizedRoleName.ToLower();
            return await DbContext.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == normalizedRoleName, cancellationToken);
        }

        //Gets the role name from the database by it's normal name
        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
            => GetRoleNameAsync(role, cancellationToken);

        //Gets the role id 
        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id.ToString());

        //Gets the role name
        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        //Sets the role name normalized in the database
        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
            => Task.CompletedTask;

        //Sets the role name in the database
        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        //Updates the role fields in the database
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
