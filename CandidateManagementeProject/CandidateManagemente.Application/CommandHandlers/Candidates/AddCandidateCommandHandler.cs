using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Domain.Entities;
using CandidateManagemente.Domain.Interface;
using MediatR;

namespace CandidateManagemente.Application.CommandHandlers.Candidates
{
    public class AddCandidateCommandHandler : IRequestHandler<AddCandidateCommand, string>
    {
        private readonly ICandidateRepository _candidateRepository;
        public AddCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task<string> Handle(AddCandidateCommand command, CancellationToken cancellationToken)
        {
            var notification = "";
            try
            {
                var candidate = new Domain.Entities.Candidates
                {
                    Name = command.Name,
                    Surname = command.Surname,
                    BirthDate = command.BirthDate,
                    Email = command.Email,
                    InsertDate = DateTime.Now
                };
                var idCandidate = _candidateRepository.AddCandidate(candidate);

                var experiences = new Experiences
                {
                    IdCandidate = idCandidate,
                    Company = command.Company,
                    Job = command.Job,
                    Salary = command.Salary,
                    Description = command.Description,
                    BeginDate = command.BeginDate,
                    EndDate = command.EndDate,
                    InsertDate = DateTime.Now
                };

                if (command.CurrentJob == true)
                    experiences.EndDate = null;

                _candidateRepository.AddExperience(experiences);
                notification = "Candidate successfully added";
                return Task.FromResult(notification);
            }
            catch (Exception ex)
            {
                notification = " There was an error registering the candidate";
                return Task.FromResult(notification);
            }
        }
    }
}
