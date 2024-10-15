using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.ADD
{
    public class AddMatchCommand : CommandBase<MatchDB, MatchDB>
    {
        public override async Task<MatchDB> Execute(HandBallLeagueContext context)
        {
            await context.Matches.AddAsync(Parametr);
            await context.SaveChangesAsync();
            return Parametr;
        }
    }
}
