using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Commands.DELETE
{
    public class DeletePlayerByIdCommand : CommandBase<PlayerDB, PlayerDB>
    {
        public override async Task<PlayerDB> Execute(HandBallLeagueContext context)
        {
            context.Players.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
