using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandBallLeague.DataAccess
{
    public class HandBallLeagueContext : DbContext
    {
        public HandBallLeagueContext(DbContextOptions<HandBallLeagueContext> opt) : base (opt)
        {
            
        }

        public DbSet<TeamDB> Teams { get; set; }

        public DbSet<PlayerDB> Players { get; set; }

        public DbSet<CoachDB> Coaches { get; set; }

        public DbSet<MatchDB> Matches { get; set; }

    }
}
