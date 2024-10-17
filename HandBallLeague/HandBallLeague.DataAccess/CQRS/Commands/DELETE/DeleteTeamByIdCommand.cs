using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.DELETE
{
    public class DeleteTeamByIdCommand : CommandBase<TeamDB, TeamDB>
    {
        public override async Task<TeamDB> Execute(HandBallLeagueContext context)
        {
            context.Teams.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
