using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.Entities
{
    public class MatchDB : EntityBase
    {
        public List<TeamDB> Teams { get; set; }

        public int Audience { get; set; }

        [Required]
        public int HostsScore { get; set; }

        [Required]
        public int GuestsScore { get; set; }
    }
}
