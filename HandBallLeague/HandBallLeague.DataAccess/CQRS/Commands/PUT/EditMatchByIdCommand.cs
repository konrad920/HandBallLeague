using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.PUT
{
    public class EditMatchByIdCommand : CommandBase<MatchDB, MatchDB>
    {
        public int MatchAudience { get; set; }

        public int MatchHostsScore { get; set; }

        public int MatchGuestsScore { get; set; }

        public int MatchGuestsTeamId { get; set; }

        public int MatchHostsTeamId { get; set; }
        public override async Task<MatchDB> Execute(HandBallLeagueContext context)
        {
            MatchGuestsScore = Parameter.GuestsScore;
            MatchHostsScore = Parameter.HostsScore;
            MatchHostsTeamId = Parameter.HostsTeamId;
            MatchGuestsTeamId = Parameter.GuestsTeamId;
            MatchAudience = Parameter.Audience;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
