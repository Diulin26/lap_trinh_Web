using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Learner
    {
        public int LearnerID { get; set; }

        [Required]
        public string FirstMidName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? MajorID { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public virtual Major Major { get; set; }
    }
}
