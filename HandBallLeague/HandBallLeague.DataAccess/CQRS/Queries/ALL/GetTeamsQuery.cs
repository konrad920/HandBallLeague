using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.ALL
{
    public class GetTeamsQuery : QueryBase<List<TeamDB>>
    {
        public override async Task<List<TeamDB>> Execute(HandBallLeagueContext context)
        {
            return await context.Teams.ToListAsync();
        }
    }
}
