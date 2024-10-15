using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.AplicationServices.API.Domain.Coaches
{
    public class AddCoachRequest : IRequest<AddCoachResponse>
    {
        public int CoachTeamDBId { get; set; }

        public string CoachName { get; set; }

        public string CoachSurname { get; set; }

        public int CoachAge { get; set; }

        public float CoachSalary { get; set; }
    }
}
