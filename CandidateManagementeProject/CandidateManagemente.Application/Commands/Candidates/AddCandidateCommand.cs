using CandidateManagemente.Domain.Entities;
using MediatR;

namespace CandidateManagemente.Application.Commands.Candidates
{
    public class AddCandidateCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool CurrentJob { get; set; }
    }
}
