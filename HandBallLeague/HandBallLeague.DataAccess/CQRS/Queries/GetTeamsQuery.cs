using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries
{
    public class GetTeamsQuery : QueryBase<List<TeamDB>>
    {
        public override Task<List<TeamDB>> Execute(HandBallLeagueContext context)
        {
            return context.Teams.ToListAsync();
        }
    }
}
