using HandBallLeague.DataAccess.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.AplicationServices.API.Domain.Matches
{
    public class AddMatchRequest : IRequest<AddMatchResponse>
    {
        public int Audience { get; set; }

        public int HostsScore { get; set; }

        public int GuestsScore { get; set; }
    }
}
