using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.BYID
{
    public class GetMatchByIdQuery : QueryBase<MatchDB>
    {
        public int MatchId { get; set; }
        public override async Task<MatchDB> Execute(HandBallLeagueContext context)
        {
            var matchFromDB = await context.Matches.FirstOrDefaultAsync(x => x.Id == MatchId);
            return matchFromDB;
        }
    }
}
