using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Matches
{
    public class DeleteMatchByIdRequest : IRequest<DeleteMatchByIdResponse>
    {
        public int Id { get; set; }
    }
}
