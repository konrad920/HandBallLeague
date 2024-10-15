using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Teams
{
    public class AddTeamRequest : IRequest<AddTeamResponse>
    {
        public string TeamName { get; set; }

        public string TeamCity { get; set; }

        public int TeamFoundingYear { get; set; }
    }
}
