using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.BYID
{
    public class GetCoachByIdQuery : QueryBase<CoachDB>
    {
        public int CoachId { get; set; }
        public override async Task<CoachDB> Execute(HandBallLeagueContext context)
        {
            var coachFromDb = await context.Coaches.FirstOrDefaultAsync(x => x.Id == CoachId);
            return coachFromDb;
        }
    }
}
