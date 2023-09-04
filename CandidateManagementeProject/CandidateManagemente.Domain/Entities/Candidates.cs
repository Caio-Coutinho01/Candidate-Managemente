using System;

namespace CandidateManagemente.Domain.Entities;
public class Candidates
{
    public int IdCandidate { get; set; }
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<Experiences> experiences { get; set; }
    public User User { get; set; }

}

