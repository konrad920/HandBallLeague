using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Players
{
    public class DeletePlayerByIdRequest : IRequest<DeletePlayerByIdResponse>
    {
        public int Id { get; set; }
    }
}
