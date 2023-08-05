using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagemente.Application.CommandHandlers.Candidates
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, string>
    {
        private readonly ICandidateRepository _candidateRepository;
        public DeleteCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task<string> Handle(DeleteCandidateCommand command, CancellationToken cancellationToken)
        {


            return Task.FromResult(_candidateRepository.Delete(command.idCandidate));
        }
    }
}
