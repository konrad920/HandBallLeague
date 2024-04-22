using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.Entities
{
    public class CoachDB : EntityBase
    {
        public int TeamDBId { get; set; }

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
