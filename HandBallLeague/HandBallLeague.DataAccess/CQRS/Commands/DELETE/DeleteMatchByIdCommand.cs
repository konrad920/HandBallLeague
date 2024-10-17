using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.DELETE
{
    public class DeleteMatchByIdCommand : CommandBase<MatchDB, MatchDB>
    {
        public override async Task<MatchDB> Execute(HandBallLeagueContext context)
        {
            context.Matches.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
