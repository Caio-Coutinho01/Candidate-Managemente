
namespace CandidateManagemente.Domain.Entities
{
    public class User 
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual Credentials Credentials { get; set; }
    }
}
