using AutoMapper;
using CandidateManagemente.Application.DTO;
using CandidateManagemente.Domain.Interface;
using MediatR;

namespace CandidateManagemente.Application.Queries.Candidates
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<CandidatesDto>>, IRequestHandler<GetCandidateDetail, List<CandidateExperiencesDto>>
    {
        private readonly ICandidateRepository _candidateRepository;
        IMapper _mapper;

        public GetCandidatesQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<List<CandidatesDto>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidates = _candidateRepository.GetAll();
            return await Task.FromResult(_mapper.Map<List<CandidatesDto>>(candidates));
        }

        public async Task<List<CandidateExperiencesDto>> Handle(GetCandidateDetail request, CancellationToken cancellationToken)
        {
            var candidates = _candidateRepository.GetId(request.Id);
            return await Task.FromResult(_mapper.Map<List<CandidateExperiencesDto>>(candidates));
        }
    }
}
