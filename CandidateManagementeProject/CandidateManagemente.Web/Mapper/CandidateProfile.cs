using AutoMapper;
using CandidateManagemente.Application.DTO;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Response;
using CandidateManagemente.Web.ViewModel;

namespace CandidateManagemente.Web.Mapper
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<CandidatesDto, Candidates>().ReverseMap();
            CreateMap<CandidateExperiencesDto, OCandidateExperiences>().ReverseMap();
            CreateMap<CandidateCompleteVM, CandidateExperiencesDto>().ReverseMap();
            CreateMap<List<CandidateCompleteVM>, CandidateCompleteVM>().ReverseMap();
        }
       
    }
}
