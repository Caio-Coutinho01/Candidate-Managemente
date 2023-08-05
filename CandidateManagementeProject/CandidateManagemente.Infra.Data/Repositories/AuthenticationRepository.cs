using Azure.Core;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Interface;
using CandidateManagemente.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagemente.Infra.Data.Repositories
{
	public class AuthenticationRepository : IAuthenticationRepository
	{
		private readonly MyCustomDbContext _dbContext;

		public AuthenticationRepository(MyCustomDbContext dbContext)
		{
			_dbContext = dbContext;
		}
        public async Task<User> GetUser(string email)
        {
            return await _dbContext.User
            .Include(u => u.Credentials).FirstOrDefaultAsync(u => u.Credentials.Email == email);
        }

        public async Task<bool> EmailExists(string email)
		{
			return await _dbContext.User.AnyAsync(u => u.Credentials.Email == email); 
		}

		public async Task AddAsync(User user)
		{
			_dbContext.User.Add(user);
			await _dbContext.SaveChangesAsync();
		}
	}
}
