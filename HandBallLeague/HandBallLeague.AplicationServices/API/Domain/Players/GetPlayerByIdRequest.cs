using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Players
{
    public class GetPlayerByIdRequest : IRequest<GetPlayerByIdResponse>
    {
        public int Id { get; set; }
    }
}
