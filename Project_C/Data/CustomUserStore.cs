using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project_C.Data;
using Project_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project_C.Data
{
	public class CustomUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>
	{
		//Makes connection with the database and roles
		public CustomUserStore(ApplicationDbContext dbContext, IRoleStore<Role> roleStore)
		{
			DbContext = dbContext;
			Roles = roleStore;
		}

		private ApplicationDbContext DbContext { get; }
		private IRoleStore<Role> Roles { get; }

		//This function connects a user to a role
        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
			user.Roles.Add(new UserRole
			{
				User = user,
				Role = await Roles.FindByNameAsync(roleName, cancellationToken)
			});
        }

		//Creates a new user and adds him to the database, also prints it in the console
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
		{
			Console.WriteLine("New user has been added to the system");
			Console.WriteLine(user.Id);
			Console.WriteLine(user.Password);

			await DbContext.AddAsync(user, cancellationToken);
			await DbContext.SaveChangesAsync(cancellationToken);

			return IdentityResult.Success;
		}

		//Deletes a new user in the database
		public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
		{
			EntityEntry<User> entity = DbContext.Remove(user);
			await DbContext.SaveChangesAsync(cancellationToken);
			if (entity.State == EntityState.Deleted)
				return IdentityResult.Success;
			return IdentityResult.Failed();
		}

		//removes a role
		public void Dispose()
		{
			Roles.Dispose();
		}

		//Finds a user id in the database
		public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
            int.TryParse(userId, out int id);
			return await DbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		//Gets the name of a user from the database in lowercase
		public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			normalizedUserName = normalizedUserName.ToLower();
			return await DbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == normalizedUserName, cancellationToken);
		}

		//Gets the normal user name from the database
		public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) => GetUserNameAsync(user, cancellationToken);

		//This function gets the hased password from the db
		public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Password);
		}

		//This method gets the role from the user
        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
			user = (await DbContext.Users
				.Include(u => u.Roles)
				.ThenInclude(ur => ur.Role)
				.FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken)
			);

			return user?.Roles.Select(ur => ur.Role.Name).ToList();
        }

		//This gets a user id from the database and converts it to a string
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken) => Task.FromResult(user.Id.ToString());

		//Gets the user name from the database
		public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken) => Task.FromResult(user.Email);

		//Returns a list of the users who are members of a role
        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
			return await DbContext.Users
				.Include(u => u.Roles)
				.ThenInclude(ur => ur.Role)
				.Where(u => u.Roles.Any(ur => ur.Role.Name == roleName))
				.ToListAsync(cancellationToken);
        }

		//Checks if the user has a password
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
		{
			return Task.FromResult(true);
		}

		//Checks if the user is a member of a given role
        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
			return (await GetRolesAsync(user, cancellationToken))
				.Contains(roleName);
        }

		//Removes a user from a role
        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
			var userRole = (await DbContext.Users
				.Include(u => u.Roles)
				.ThenInclude(ur => ur.Role)
				.FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken)
			)?.Roles.FirstOrDefault(ur => ur.Role.Name == roleName);

			if (userRole is null) return;

            DbContext.Remove(userRole);
			await DbContext.SaveChangesAsync(cancellationToken);
        }

		//Sets the normalized username in the database
        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		//Sets the password and hashes it before putting it in the database
		public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
		{
			user.Password = passwordHash;
			return Task.CompletedTask;
		}

		//Sets the user email as his user name
		public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
		{
			user.Email = userName;
			return Task.CompletedTask;
		}

		//Updates the user profile and saves it in the database
		public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
		{
			EntityEntry<User> entry = DbContext.Update(user);
			await DbContext.SaveChangesAsync(cancellationToken);
			if (entry.State == EntityState.Detached)
				return IdentityResult.Failed();
			return IdentityResult.Success;
		}
	}
}
