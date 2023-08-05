namespace CandidateManagemente.Domain.Response
{
    public class OCandidateExperiences
    {
        public int IdCandidate { get; set; }
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
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
