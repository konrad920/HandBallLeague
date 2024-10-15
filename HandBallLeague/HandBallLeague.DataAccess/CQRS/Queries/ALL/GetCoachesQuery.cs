using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.ALL
{
    public class GetCoachesQuery : QueryBase<List<CoachDB>>
    {
        public override Task<List<CoachDB>> Execute(HandBallLeagueContext context)
        {
            return context.Coaches.ToListAsync();
        }
    }
}
