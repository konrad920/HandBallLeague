using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Coaches
{
    public class GetCoachByIdRequest : IRequest<GetCoachByIdResponse>
    {
        public int Id { get; set; }
    }
}
