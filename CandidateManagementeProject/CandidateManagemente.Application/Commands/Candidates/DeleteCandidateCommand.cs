using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagemente.Application.Commands.Candidates
{
    public class DeleteCandidateCommand : IRequest<string>
    {
        public int idCandidate { get; set; }
    }
}
