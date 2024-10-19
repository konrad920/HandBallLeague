using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandBallLeague.DataAccess.Entities
{
    public class CoachDB : EntityBase
    {
        public int TeamDBId { get; set; }

        public TeamDB TeamDB { get; set; }

        [Required]
        [MaxLength(150)]
        public string NameOfCoach { get; set; }

        [Required]
        [MaxLength(150)]
        public string SurnameOfCoach { get; set; }

        public int AgeOfCoach { get; set; }

        public float Salary { get; set; }
    }
}
