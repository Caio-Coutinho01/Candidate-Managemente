using CandidateManagemente.Application.DTO;
using CandidateManagemente.Domain.Response;
using MediatR;

namespace CandidateManagemente.Application.Queries.Candidates
{
    public class GetCandidatesQuery : IRequest<List<CandidatesDto>>
    {
    }
    public class GetCandidateDetail : IRequest<List<CandidateExperiencesDto>>
    {
        public int Id { get; set; }
    }
}
