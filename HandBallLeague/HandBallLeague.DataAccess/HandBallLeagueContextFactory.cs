using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HandBallLeague.DataAccess
{
    public class HandBallLeagueContextFactory : IDesignTimeDbContextFactory<HandBallLeagueContext>
    {
        public HandBallLeagueContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HandBallLeagueContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-QIGQKKJP\\SQLEXPRESS01;Initial Catalog=HandBallLeague;Integrated Security=True;TrustServerCertificate=True");
            return new HandBallLeagueContext(optionsBuilder.Options);
        }
    }
}
