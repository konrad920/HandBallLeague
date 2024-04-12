using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.Entities
{
    public class PlayerDB : EntityBase
    {
        public int TeamDBId { get; set; }

        public TeamDB TeamDB { get; set; }

        [Required]
        [MaxLength(150)]
        public string NameOfPlayer { get; set; }

        [Required]
        [MaxLength(150)]
        public string SurnameOfPlayer { get; set; }

        [Required]
        [MaxLength(150)]
        public string Position { get; set; }

        public int AgeOfPlayer { get; set; }

        public float Salary { get; set; }
    }
}
