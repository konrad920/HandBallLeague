using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.ALL
{
    public class GetPlayersQuery : QueryBase<List<PlayerDB>>
    {
        public override Task<List<PlayerDB>> Execute(HandBallLeagueContext context)
        {
            return context.Players.ToListAsync();
        }
    }
}
