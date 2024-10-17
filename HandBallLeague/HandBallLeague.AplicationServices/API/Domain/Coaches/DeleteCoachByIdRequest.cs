using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Coaches
{
    public class DeleteCoachByIdRequest : IRequest<DeleteCoachByIdResponse>
    {
        public int Id { get; set; }
    }
}
