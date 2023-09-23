using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Response;

namespace CandidateManagemente.Domain.Interface
{
    public interface ICandidateRepository
    {
        List<Candidates> GetAllCandidates(int IdUser);
        List<OCandidateExperiences> GetId(int IdCandidate, int IdUser);
        int AddCandidate(Candidates obj);
        Task AddExperience(Experiences obj);
        string Update(OCandidateExperiences obj);
        string Delete(int Id);
    };
}
