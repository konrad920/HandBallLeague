using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.ADD
{
    public class AddTeamCommand : CommandBase<TeamDB, TeamDB>
    {
        public override async Task<TeamDB> Execute(HandBallLeagueContext context)
        {
            await context.Teams.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
