using CandidateManagemente.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CandidateManagemente.Application.DTO
{
    public class CandidatesDto
    {
        [ScaffoldColumn(false)]
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        
    }
}
