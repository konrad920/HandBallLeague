using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess.CQRS.Queries.ALL
{
    public class GetPlayersQuery : QueryBase<List<PlayerDB>>
    {
        public override async Task<List<PlayerDB>> Execute(HandBallLeagueContext context)
        {
            var teams = await context.Teams.ToListAsync();

            var players = await context.Players.ToListAsync();
            foreach (var player in players)
            {
                player.TeamDB = teams.FirstOrDefault(x => x.Id == player.TeamDBId);
            }
            return players;
        }
    }
}
