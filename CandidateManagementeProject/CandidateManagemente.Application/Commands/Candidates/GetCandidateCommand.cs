using CandidateManagemente.Application.DTO;
using MediatR;

namespace CandidateManagemente.Application.Commands.Candidates
{
    public class GetCandidateCommand : IRequest<CandidateDataResponse>
    {
        public int IdUser { get; set; }
        public int? IdCandidate { get; set; }
    }
}
