using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.BYID
{
    public class GetTeamByIdQuery : QueryBase<TeamDB>
    {
        public int TeamId { get; set; }
        public override async Task<TeamDB> Execute(HandBallLeagueContext context)
        {
            var teamFromDB =  await context.Teams.FirstOrDefaultAsync(x => x.Id == TeamId);
            return teamFromDB;
        }
    }
}
