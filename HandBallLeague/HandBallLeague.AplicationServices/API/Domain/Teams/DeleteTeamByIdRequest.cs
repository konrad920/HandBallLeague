using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Teams
{
    public class DeleteTeamByIdRequest : IRequest<DeleteTeamByIdResponse>
    {
        public int Id { get; set; }
    }
}
