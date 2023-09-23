using AutoMapper;
using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Application.DTO;
using CandidateManagemente.Domain.Interface;
using MediatR;

namespace CandidateManagemente.Application.Queries.Candidates
{
    public class GetCandidateCommandHandler : IRequestHandler<GetCandidateCommand, CandidateDataResponse>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidateCommandHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<CandidateDataResponse> Handle(GetCandidateCommand request, CancellationToken cancellationToken)
        {
            var response = new CandidateDataResponse();

            if (request.IdCandidate.HasValue)
            {
                var candidateDetails = _candidateRepository.GetId(request.IdCandidate.Value, request.IdUser);
                response.CandidateExperiences = _mapper.Map<List<CandidateExperiencesDto>>(candidateDetails);
            }

            var candidates = _candidateRepository.GetAllCandidates(request.IdUser);
            response.Candidates = _mapper.Map<List<CandidatesDto>>(candidates);

            return await Task.FromResult(response);
        }
    }
}

