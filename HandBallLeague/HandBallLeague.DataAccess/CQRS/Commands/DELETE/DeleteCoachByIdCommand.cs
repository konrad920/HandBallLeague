using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.DELETE
{
    public class DeleteCoachByIdCommand : CommandBase<CoachDB, CoachDB>
    {
        public override async Task<CoachDB> Execute(HandBallLeagueContext context)
        {
            context.Coaches.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
