using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.BYID
{
    public class GetPlayerByIdQuery : QueryBase<PlayerDB>
    {
        public int PlayerId { get; set; }
        public override async Task<PlayerDB> Execute(HandBallLeagueContext context)
        {
            var playerFromDB = await context.Players.FirstOrDefaultAsync(x => x.Id == PlayerId);
            playerFromDB.TeamDB = await context.Teams.FirstOrDefaultAsync(y => y.Id == playerFromDB.TeamDBId);
            return playerFromDB;
        }
    }
}
