using HandBallLeague.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.CQRS.Commands.PUT
{
    public class EditPlayerByIdCommand : CommandBase<PlayerDB, PlayerDB>
    {
        public int PlayerTeamId { get; set; }

        public string ? PlayerName { get; set; }

        public string ? PlayerSurname { get; set; }

        public string ? PlayerPosition { get; set; }

        public float PlayerSalary { get; set; }

        public int PlayerAge { get; set; }

        public override async Task<PlayerDB> Execute(HandBallLeagueContext context)
        {
            Parameter.NameOfPlayer = PlayerName;
            Parameter.SurnameOfPlayer = PlayerSurname;
            Parameter.Salary = PlayerSalary;
            Parameter.Position= PlayerPosition;
            Parameter.TeamDBId = PlayerTeamId;
            Parameter.AgeOfPlayer = PlayerAge;
            context.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
