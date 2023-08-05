using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Domain.Interface;
using CandidateManagemente.Domain.Response;
using MediatR;

namespace CandidateManagemente.Application.CommandHandlers.Candidates
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, string>
    {
        private readonly ICandidateRepository _candidateRepository;
        public UpdateCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task<string> Handle(UpdateCandidateCommand command, CancellationToken cancellationToken)
        {
            var candidatesExperiences = new OCandidateExperiences
            {

                Name = command.Name,
                Surname = command.Surname,
                BirthDate = command.BirthDate,
                Email = command.Email,
                IdCandidate = command.IdCandidate,
                Company = command.Company,
                Job = command.Job,
                Salary = command.Salary,
                Description = command.Description,
                BeginDate = command.BeginDate,
                EndDate = command.EndDate,
            };
            if (command.CurrentJob == true)
                candidatesExperiences.EndDate = null;

            return Task.FromResult(_candidateRepository.Update(candidatesExperiences));
        }
    }
}
