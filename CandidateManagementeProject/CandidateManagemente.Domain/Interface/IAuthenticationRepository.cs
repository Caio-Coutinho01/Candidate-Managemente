using CandidateManagemente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagemente.Domain.Interface
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUser(string email);
        Task<bool> EmailExists(string email);
        Task AddAsync(User user);
    }
}
