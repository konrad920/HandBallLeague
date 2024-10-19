namespace HandBallLeague.AplicationServices.API.Domain.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int HostsScore { get; set; }

        public int GuestsScore { get; set;}

        public int HostsTeamId { get; set; }

        public int GuestsTeamId { get; set; }
    }
}
