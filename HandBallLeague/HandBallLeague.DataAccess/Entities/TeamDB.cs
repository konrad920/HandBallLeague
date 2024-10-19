using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.Entities
{
    public class TeamDB : EntityBase
    {
        public List<PlayerDB> Players { get; set; }

        public CoachDB CoachDB { get; set; }

        public List<MatchDB> Matches { get; set; }

        [Required]
        [MaxLength(200)]
        public string NameOfTeam { get; set; }

        [Required]
        [MaxLength(200)]
        public string CityOfTeam { get; set; }

        public int FoundingYear { get; set; }

        public float BudgetOfTeam { get; set; }
    }
}
