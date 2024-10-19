using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.PUT
{
    public class EditTeamByIdCommand : CommandBase<TeamDB, TeamDB>
    {
        public string TeamName { get; set; }

        public string TeamCity { get; set; }

        public int TeamFoundingYear { get; set; }

        public float TeamBudget { get; set; }
        public override async Task<TeamDB> Execute(HandBallLeagueContext context)
        {
            TeamName = Parameter.NameOfTeam;
            TeamCity = Parameter.CityOfTeam;
            TeamBudget = Parameter.BudgetOfTeam;
            TeamFoundingYear = Parameter.FoundingYear;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
