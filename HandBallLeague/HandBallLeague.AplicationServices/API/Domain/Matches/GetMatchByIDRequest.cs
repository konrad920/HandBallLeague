using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Matches
{
    public class GetMatchByIDRequest : IRequest<GetMatchByIDResponse>
    {
        public int Id { get; set; }
    }
}
