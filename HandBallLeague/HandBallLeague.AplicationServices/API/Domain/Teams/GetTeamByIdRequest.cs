using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Teams
{
    public class GetTeamByIdRequest : IRequest<GetTeamByIdResponse>
    {
        public int Id { get; set; }
    }
}
