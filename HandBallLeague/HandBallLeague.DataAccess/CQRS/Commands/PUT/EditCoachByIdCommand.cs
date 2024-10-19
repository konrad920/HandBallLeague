using HandBallLeague.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.CQRS.Commands.PUT
{
    public class EditCoachByIdCommand : CommandBase<CoachDB, CoachDB>
    {
        public int CoachTeamDBId { get; set; }

        public string CoachNameOfCoach { get; set; }

        public string CoachSurnameOfCoach { get; set; }

        public int CoachAgeOfCoach { get; set; }

        public float CoachSalary { get; set; }
        public override async Task<CoachDB> Execute(HandBallLeagueContext context)
        {
            Parameter.TeamDBId = CoachTeamDBId;
            Parameter.Salary = CoachSalary;
            Parameter.SurnameOfCoach = CoachNameOfCoach;
            Parameter.NameOfCoach = CoachSurnameOfCoach;
            Parameter.AgeOfCoach = CoachAgeOfCoach;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
