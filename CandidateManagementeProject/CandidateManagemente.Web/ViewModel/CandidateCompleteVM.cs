using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CandidateManagemente.Web.ViewModel
{
    public class CandidateCompleteVM
    {
        [ScaffoldColumn(false)]
        [Key]
        public int IdCandidate { get; set; }

        [Required(ErrorMessage = "Fill in the name field")]
        [MinLength(2, ErrorMessage = "Minimum {0} characters")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill in the surname field")]
        [MinLength(2, ErrorMessage = "Minimum{0} characters")]
        [MaxLength(150, ErrorMessage = "Maximum{0} characters")]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Fill in the birthdate field")]
        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Fill in the e-mail field")]
        [MinLength(2, ErrorMessage = "Minimum{0} characters")]
        [MaxLength(250, ErrorMessage = "Maximum{0} characters")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        [DisplayName("E-mail")]
        public string Email { get; set; }


        [ScaffoldColumn(false)]
        [Key]
        public int IdCandidateExperience { get; set; }
        //public int IdCandidate { get; set; }

        [Required(ErrorMessage = "Fill in the company field")]
        [MinLength(2, ErrorMessage = "Minimum {0} characters")]
        [MaxLength(100, ErrorMessage = "Maximum {0} characters")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Fill in the job field")]
        [MinLength(2, ErrorMessage = "Minimum {0} characters")]
        [MaxLength(100, ErrorMessage = "Maximum {0} characters")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Fill in the name field")]
        [MinLength(2, ErrorMessage = "Minimum {0} characters")]
        [MaxLength(4000, ErrorMessage = "Maximum {0} characters")]
        public string Description { get; set; }

        
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Fill in the birthdate field")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime InsertDate { get; set; }

        public bool CurrentJob { get; set; }
    }
}
