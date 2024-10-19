using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.ALL
{
    public class GetMatchesQuery : QueryBase<List<MatchDB>>
    {
        public override async Task<List<MatchDB>> Execute(HandBallLeagueContext context)
        {
            return await context.Matches.ToListAsync();
        }
    }
}
