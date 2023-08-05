using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Response;

namespace CandidateManagemente.Domain.Interface
{
    public interface ICandidateRepository
    {
        List<Candidates> GetAll();
        List<OCandidateExperiences> GetId(int Id);
        int AddCandidate(Candidates obj);
        Task AddExperience(Experiences obj);
        string Update(OCandidateExperiences obj);
        string Delete(int Id);
    };
}
