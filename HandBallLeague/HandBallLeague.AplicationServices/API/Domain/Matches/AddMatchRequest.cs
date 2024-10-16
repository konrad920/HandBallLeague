using MediatR;

namespace HandBallLeague.AplicationServices.API.Domain.Matches
{
    public class AddMatchRequest : IRequest<AddMatchResponse>
    {
        public int MatchAudience { get; set; }

        public int MatchHostsScore { get; set; }

        public int MatchQuestScore { get; set; }
    }
}
