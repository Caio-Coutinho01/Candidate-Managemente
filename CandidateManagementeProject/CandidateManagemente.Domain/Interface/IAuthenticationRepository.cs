using CandidateManagemente.Domain.Entities;

namespace CandidateManagemente.Domain.Interface
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUser(string email);
        Task<bool> EmailExists(string email);
        Task AddAsync(User user);
    }
}
