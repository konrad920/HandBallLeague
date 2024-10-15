using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.ADD
{
    public class AddCoachCommand : CommandBase<CoachDB, CoachDB>
    {
        public override async Task<CoachDB> Execute(HandBallLeagueContext context)
        {
            await context.Coaches.AddAsync(Parametr);
            await context.SaveChangesAsync();
            return Parametr;
        }
    }
}
